// app/routes.js
module.exports = function(app, passport) {
	var bcrypt = require('bcrypt-nodejs');
	// =====================================
	// lists	                  ========
	// =====================================
	app.get('/listsS', isLoggedIn, function(req,res){
		var mysql = require('mysql');
		var dbconfig = require('/var/www/html/js/config/database');
		var connection = mysql.createConnection(dbconfig.connection);
		connection.query('USE ' + dbconfig.database);
		connection.query("SELECT * from tb_students", function(err,rows){
			if(err)
				console.log(err);
			
			res.render('listsS.ejs',{students:rows,  message: req.flash('loginMessage') });
		});
		connection.end(function(err){
			if(err)
				throw err;
		});
	});
	
	app.post('/deleteStudent', isLoggedIn, function(req,res){
		var mysql = require('mysql');
		var dbconfig = require('/var/www/html/js/config/database');
		var connection = mysql.createConnection(dbconfig.connection);
		connection.query('USE ' + dbconfig.database);
		var id ;
		connection.query('select * from tb_students where id=?',[req.body.hidID],function(err,rows){
			if(err)
				res.render('listsS.ejs',{message:"????? ??????, ??? ??? ????"});
			
			connection.query('delete from tb_students where id=?',[req.body.hidID],function(err,rows){
				if(err)
					res.render('listsS.ejs',{message:"????? ??????, ??? ??? ????"});
				else{
					connection.end();
					res.redirect('/listsS');
				}
				
			});
		});
		
	});
	
	app.post('/editStudent', isLoggedIn, function(req,res){
		var mysql = require('mysql');
		var dbconfig = require('/var/www/html/js/config/database');
		var connection = mysql.createConnection(dbconfig.connection);
		connection.query('USE ' + dbconfig.database);
		console.log("hidID: "+  req.body.hidID);
		connection.query("SELECT * from tb_students where id =? ",[req.body.hidID], function(err,rows){
			if(err)
				console.log(err);
				console.log("row[0]: "+rows[0]);
			rows[0].student = '1';
			rows[0].admin = '0';
			rows[0].teacher = '0';
			rows[0].scholar = '0';
			rows[0].super = '1';
			res.render('update.ejs',{user: rows[0]});
		});
		connection.end(function(err){
			if(err)
				throw err;
		});
	});
	
	app.get('/lists', isLoggedIn, function(req,res){
		var mysql = require('mysql');
		var dbconfig = require('/var/www/html/js/config/database');
		var connection = mysql.createConnection(dbconfig.connection);
		connection.query('USE ' + dbconfig.database);
		connection.query("SELECT tb_teachers.*,users.username from tb_teachers,users where(users.id = account_id)", function(err,rows){
			if(err)
				console.log(err);
			
			res.render('lists.ejs',{teachers:rows,  message: req.flash('loginMessage') });
		});
		connection.end(function(err){
			if(err)
				throw err;
		});
	});
	
	app.post('/deleteTeacher', isLoggedIn, function(req,res){
		var mysql = require('mysql');
		var dbconfig = require('/var/www/html/js/config/database');
		var connection = mysql.createConnection(dbconfig.connection);
		connection.query('USE ' + dbconfig.database);
		var id ;
		connection.query('select * from tb_teachers where id=?',[req.body.hidID],function(err,rows){
			if(err)
				res.render('lists.ejs',{message:"????? ??????, ??? ??? ????"});
			id = rows[0].account_id;
		});
		connection.query('delete from tb_teachers where id=?',[req.body.hidID],function(err,rows){
			if(err)
				res.render('lists.ejs',{message:"????? ??????, ??? ??? ????"});
			
			else if(id){
				
				connection.query('delete from users where id=?',[id],function(err,rows){
					if(err)
						console.log(err);
					else{
						connection.end();
						res.redirect('/lists');
						}
				});
				
			}
			
		});
		
	});
	
	app.post('/editTeacher', isLoggedIn, function(req,res){
		var mysql = require('mysql');
		var dbconfig = require('/var/www/html/js/config/database');
		var connection = mysql.createConnection(dbconfig.connection);
		connection.query('USE ' + dbconfig.database);

		connection.query("SELECT users.*,tb_teachers.city,tb_teachers.phone,tb_teachers.account_id from tb_teachers, users where(users.id = account_id) and tb_teachers.id =? ",[req.body.hidID], function(err,rows){
			if(err)
				console.log(err);
			rows[0].super = '1';
			res.render('update.ejs',{user: rows[0]});
		});
		connection.end(function(err){
			if(err)
				throw err;
		});
	});
		
	
	app.post('/lists', passport.authenticate('local-lists', {
	     
            successRedirect : '/lists', // redirect to the secure profile section
            failureRedirect : '/login', // redirect back to the signup page if there is an error
            failureFlash : true // allow flash messages
		}),
        function(req, res) {
	 console.log("Dddddfdsffs");
        res.redirect('lists.ejs');
    });
	
	// =====================================
	// update page                  ========
	// =====================================

	app.get('/update', isLoggedIn, function(req, res) {
		res.render('update.ejs', {
			user : req.user // get the user out of session and pass to template
		});
	});
	app.post('/update', function(req,res){
		var mysql = require('mysql');
		var dbconfig = require('/var/www/html/js/config/database');
		var connection = mysql.createConnection(dbconfig.connection);
		connection.query('USE ' + dbconfig.database);
		console.log("heeeerreee1 "+ req.body.uIDs);
		var id = req.body.uIDs;
		if(req.body.p.teacher=='1'){
			connection.query('select * from tb_teachers where account_id=?',[id],function(err,rows){
				if(err)
					res.redirect('/bs');
				else{
					id = rows[0].account_id;
				}
			});
		}
		if(req.body.p.student!='1'){
			connection.query('select * from users where id=?',[id],function(err,rows){
				
				console.log("heeeerreee5 "+ id);
				if(err)
					res.redirect('/bs');
				else if(req.body.oldPassword && !bcrypt.compareSync(req.body.oldPassword, rows[0].password)){
					res.redirect('/bs');
				}
				else{
					if(req.body.oldPassword){
					console.log("heeeerreee3 "+ req.body.p.teacher);
						connection.query('update users set password=? where id=?',[bcrypt.hashSync(req.body.password,null,null), id]);
					}
					
					connection.query('update users set first_name=?, last_name=?, email=?, admin=?, scholar=? where id=?',[req.body.firstName,req.body.lastName,req.body.email,req.body.p.admin,req.body.p.schT,id],function(err,rows){
						console.log("heeeerreee2 "+ req.body.p.teacher);
						if(err)
						res.redirect('/bs');
					
						else if(req.body.p.teacher=='1'){
						connection.query('update tb_teachers set firstname=?, lastname=?, email=?, city=?, phone=?, scholar=? where account_id=?',[req.body.firstName,req.body.lastName,req.body.email,req.body.city,req.body.phone,req.body.p.schT,req.body.uIDs],function(err,rows){
							if(err)
								res.redirect('/bs');
							else{
								connection.end();
								res.redirect('/as');
							}
						});
						}
						else{
							connection.end();
							res.redirect('/as');
						}
					} );
				}
			});
			
		}
		else{
			connection.query('update tb_students set firstname=?, lastname=?, email=?, city=?, phone=? where id=?',[req.body.firstName,req.body.lastName,req.body.email,req.body.city,req.body.phone,req.body.uIDs],function(err,rows){
				if(err)
					res.redirect('/bs');
				else
					res.redirect('/as');
				
			});
		}
	});

	// =====================================
	// HOME PAGE (with login links) ========
	// =====================================
	app.get('/', isLoggedIn, function(req, res) {
		
		
		res.render('profile.ejs', {
			user : req.user // get the user out of session and pass to template
			
		}
		);
	});
	
	app.get('/index.ejs', function(req,res){
		res.render('index.ejs');
	});

	// =====================================
	// LOGIN ===============================
	// =====================================
	// show the login form
	app.get('/login', function(req, res) {

		// render the page and pass in any flash data if it exists
		res.render('login.ejs', { message: req.flash('loginMessage') });
	});

	// process the login form
	app.post('/login', passport.authenticate('local-login', {
            successRedirect : '/profile', // redirect to the secure profile section
            failureRedirect : '/login', // redirect back to the signup page if there is an error
            failureFlash : true // allow flash messages
		}),
        function(req, res) {
            console.log("hello");

            if (req.body.remember) {
              req.session.cookie.maxAge = 1000 * 60 * 3;
            } else {
              req.session.cookie.expires = false;
            }
        res.redirect('index.ejs');
    });

	// =====================================
	// SIGNUP ==============================
	// =====================================
	// show the signup form
	app.get('/signup',isLoggedIn, function(req, res) {
		// render the page and pass in any flash data if it exists
		res.render('signup.ejs', { message: req.flash('signupMessage') });
	});

	// process the signup form
	app.post('/signup', function(req,res){
		var mysql = require('mysql');
		var dbconfig = require('/var/www/html/js/config/database');
		var connection = mysql.createConnection(dbconfig.connection);
		connection.query('USE ' + dbconfig.database);
		var x = "";
		if(req.body.username)
			x = req.body.username;
		connection.query('select * from users where username = ? or email = ?',[x, req.body.email],function(err,rows){
			if(err)
				res.render('signup.ejs',{message : "Error with database connection, please try again"});
			if(rows[0]){
				if(rows[0].email == req.body.email)
					res.render('signup.ejs',{admin: '1', message : "Email address is already registered"});
				else
					res.render('signup.ejs',{admin: '1', message : "Username is already taken"});
			}
			else{
				if(req.body.studentP!='1')
				{
					var insertQuery = "INSERT INTO users ( username, password, first_name, last_name, admin,teacher,scholar,email) values (?,?,?,?,?,?,?,?)";
					var ad = '0';
					if(req.body.teacherP !="1")
						ad = '1';
					connection.query(insertQuery, [req.body.username, bcrypt.hashSync(req.body.password,null,null), req.body.firstName, req.body.lastName, ad, req.body.teacherP, req.body.schT, req.body.email],function(err, rows) {
						if(err)
							res.render('signup.ejs',{admin: '1', message : "Error with database connection, please try again"});
						var id = rows.insertId;
						if(req.body.teacherP =="1"){
							var insertQuery = "INSERT INTO tb_teachers(firstname, lastname, phone, city, email, scholar, account_id) values (?,?,?,?,?,?,?)";
							connection.query(insertQuery,[req.body.firstName,req.body.lastName,req.body.phone,req.body.city,req.body.email,req.body.schT, id],function(err, rows) {
							if(err)
								res.render( 'signup.ejs',{admin: '1',message : "Error with database connection, please try again"});
							});
						}
				
					});
			
				}
				else{
				
					var insertQuery = "INSERT INTO tb_students(firstname, lastname, phone, city, email) values (?,?,?,?,?)";
					connection.query(insertQuery,[req.body.firstName, req.body.lastName, req.body.phone, req.body.city, req.body.email], function(err,rows){
						if(err)
							res.render('signup.ejs',{admin: '1', message : "Error with database connection, please try again"});
							
					});
				}
				
				res.redirect('/as');
			}
		} );
		
		
		
	});
	app.get('/as',function(req,res){
		res.render('as.ejs');
	});
	
	app.get('/bs',function(req,res){
		res.render('bs.ejs');
	});
	// =====================================
	// PROFILE SECTION =========================
	// =====================================
	// we will want this protected so you have to be logged in to visit
	// we will use route middleware to verify this (the isLoggedIn function)
	app.get('/profile', isLoggedIn, function(req, res) {
		var mysql = require('mysql');
		var dbconfig = require('/var/www/html/js/config/database');
		var connection = mysql.createConnection(dbconfig.connection);
		connection.query('USE ' + dbconfig.database);
		var x;
		connection.query('select * from tb_teachers where scholar="1"',function(err,rows){
			if(err)
				console.log(err);
			else{	
				res.render('profile.ejs', {
					teachers: rows,
					user : req.user // get the user out of session and pass to template
				});
			}
		});
		
		
	});

	// =====================================
	// LOGOUT ==============================
	// =====================================
	app.get('/logout', function(req, res) {
		req.logout();
		res.redirect('index.ejs');
	});
};

// route middleware to make sure
function isLoggedIn(req, res, next) {

	// if user is authenticated in the session, carry on
	if (req.isAuthenticated())
		return next();

	// if they aren't redirect them to the home page
	res.redirect('index.ejs');
}
