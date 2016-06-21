// config/passport.js

// load all the things we need
var LocalStrategy   = require('passport-local').Strategy;

// load up the user model
var mysql = require('mysql');
var bcrypt = require('bcrypt-nodejs');
var dbconfig = require('./database');
var connection = mysql.createConnection(dbconfig.connection);

connection.query('USE ' + dbconfig.database);
// expose this function to our app using module.exports
module.exports = function(passport) {

    // =========================================================================
    // passport session setup ==================================================
    // =========================================================================
    // required for persistent login sessions
    // passport needs ability to serialize and unserialize users out of session

    // used to serialize the user for the session
    passport.serializeUser(function(user, done) {
        done(null, user.id);
    });

    // used to deserialize the user
    passport.deserializeUser(function(id, done) {
        connection.query("SELECT * FROM users WHERE id = ? ",[id], function(err, rows){
		console.log(rows[0].admin);
		if(rows[0].admin=="0"){
			 connection.query(" select users.*, tb_teachers.phone, tb_teachers.city from users,tb_teachers where users.id=tb_teachers.account_id and users.id = ? ",[id], function(err, rows){
				console.log("no admin");
				done(err, rows[0]);

			});
		}
		else
            		done(err, rows[0]);
        });
    });

    // =========================================================================
    // LOCAL SIGNUP ============================================================
    // =========================================================================
    // we are using named strategies since we have one for login and one for signup
    // by default, if there was no name, it would just be called 'local'

    passport.use(
        'local-signup',
        new LocalStrategy({
            // by default, local strategy uses username and password, we will override with email
            usernameField : 'username',
            passwordField : 'password',
	     
            passReqToCallback : true // allows us to pass back the entire request to the callback
        },
        function(req, username, password, done) {
            // find a user whose email is the same as the forms email
            // we are checking to see if the user trying to login already exists
            connection.query("SELECT * FROM users WHERE username = ?",[username], function(err, rows) {
                if (err)
                    return done(err);
                if (rows.length) {
                    return done(null, false, req.flash('signupMessage', 'That username is already taken.'));
                } else {
                    // if there is no user with that username
                    // create the user
                    var newUserMysql = {
                        username: username,
                        password: bcrypt.hashSync(password, null, null),  // use the generateHash function in our user model
			   firstName: req.body.firstName,
			   lastName: req.body.lastName,
			   email: req.body.email,
			   admin: req.body.adminP,
			   teacher: req.body.teacherP,
			   student: req.body.studentP,
			   schT: req.body.schT
                    };
			
			
			var id;
                    var insertQuery = "INSERT INTO users ( username, password, first_name, last_name, admin, email) values (?,?,?,?,?,?)";
			var returnVal ;
                    connection.query(insertQuery,[req.body.username, newUserMysql.password, req.body.firstName, req.body.lastName,req.body.admin, req.body.email],function(err, rows) {
			  if(err){
				console.log("err: "+err);
				console.log(req.body);
				}
			 else{
				newUserMysql.id = rows.insertId;
				id = newUserMysql.id;
				console.log("after users, id: " + id);
				var tbl = "tb_teachers";
			if(req.body.teacherP=="1")
				tbl = "tb_teachers";
			else if(req.body.adminP=="1")
				tbl = "admin";
			else if(req.body.studentP=="1")
				tbl = "tb_students";
			
			var sch = "";
			var schP = "";
			if(req.body.schT=="1"){
				sch =", scholar";
				schP = ",'1'";
			}
			
			if(tbl!="admin"){
				
				var insertQuery = "INSERT INTO "+ tbl +" (firstname, lastname, phone, city, email"+sch+", account_id) values (?,?,'0523850090','beit shemesh',?"+schP+",?)";
				console.log("running: " +insertQuery);
				console.log("id: "+newUserMysql.id);
                   		 connection.query(insertQuery,[newUserMysql.firstName,newUserMysql.lastName,newUserMysql.email,newUserMysql.id],function(err, rows) {
			  		if(err){
					console.log("err: "+err);
					console.log(insertQuery);
					console.log(newUserMysql);
					}
					else
						console.log(insertQuery);
								  return returnVal; 	

				});
			}
                     	returnVal = done(null, newUserMysql);
				 return returnVal;
			}
				
				
                    });
			
			
			


                }
            });
        })
    );
        // =========================================================================
    // LOCAL LOGIN =============================================================
    // =========================================================================
    // we are using named strategies since we have one for login and one for signup
    // by default, if there was no name, it would just be called 'local'

    passport.use(
        'local-login',
        new LocalStrategy({
            // by default, local strategy uses username and password, we will override with email
            usernameField : 'username',
            passwordField : 'password',
            passReqToCallback : true // allows us to pass back the entire request to the callback
        },
        function(req, username, password, done) { // callback with email and password from our form
            connection.query("SELECT * FROM users WHERE username = ?",[username], function(err, rows){
                if (err)
                    return done(err);
                if (!rows.length) {
                    return done(null, false, req.flash('loginMessage', 'No user found.')); // req.flash is the way to set flashdata using connect-flash
                }

                // if the user is found but the password is wrong
                if (!bcrypt.compareSync(password, rows[0].password))
                    return done(null, false, req.flash('loginMessage', 'Oops! Wrong password.')); // create the loginMessage and save it to session as flashdata

                // if user is not an admin
		if((rows[0].admin)=="0"){
			connection.query(" select users.*, tb_teachers.phone, tb_teachers.city from users,tb_teachers where users.id=tb_teachers.account_id and username = ?",[username], function(err, rows){
                if (err)
                    return done(err);
			console.log(rows[0]);
		  return done(null, rows[0]);
		  });
		}
		else
		{
              console.log(rows[0]); 
		 return done(null, rows[0]);
		}
            });
        })
    );



//================ lists
passport.use(
        'local-lists',
        new LocalStrategy(
        function(req, done) { // callback with email and password from our form
		console.log("Dddddddd");  
		connection.query("SELECT * FROM tb_teachers ", function(err, rows){
                if (err)
                    return done(err);
                if (!rows.length) {
                    return done(null, false, req.flash('loginMessage', 'No teacher found.')); // req.flash is the way to set flashdata using connect-flash
                }
		  
			console.log(rows);
                return done(null, rows[0]);
            });
        })
    );

};
