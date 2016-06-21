function showMain(){

    
    document.getElementById('mainPage').style.display="block";
    document.getElementById('framePart').style.display="none";
    document.getElementById('fillHours').style.display="none";
}
function parentIndex(){
    parent.document.location.href ="/profile";
}
function signup(id){
        
        document.getElementById('framePart').innerHTML = " <center><iframe id='ifr' src='/signup' ></iframe></center>";
        window.frames[0].onload = function(){
            //alert(document.getElementById('ifr').contentWindow.location);
            document.getElementById('ifr').contentWindow.uncheckAll();          
            document.getElementById('ifr').contentWindow.reCheckMe(id);
             
        }
        //alert(document.getElementById('ifr').contentWindow.location);
        document.getElementById('mainPage').style.display="none";
        document.getElementById('fillHours').style.display="none";
        document.getElementById('framePart').style.display="inline";
}


function editTeacher(id){
    var formId = "listForm" + id;
    document.getElementById(formId).setAttribute("action","/editTeacher");
}
function deleteTeacher(id){
    var formId = "listForm" + id;
    document.getElementById(formId).setAttribute("action","/deleteTeacher");
}

function editStudent(id){
    var formId = "listForm" + id;
    document.getElementById(formId).setAttribute("action","/editStudent");
}
function deleteStudent(id){
    var formId = "listForm" + id;
    document.getElementById(formId).setAttribute("action","/deleteStudent");
}

/* this controls all of the hours reports */
function lists(id,url){
     
     var loc = url;
    //document.getElementById('ifr').setAttribute("src",loc);
    
    document.getElementById('framePart').innerHTML = " <center><iframe id='ifr' src='"+loc+"' ></iframe></center>";
    
    window.frames[0].onload = function(){
        //alert(document.getElementById('ifr').contentWindow.location.href)  ;
        
        if(id=="all"){
            
            var x="<h4>מורה</h4><select name='teacherU' id='teacherU'>" ;
             x += "<option value='רחל'>רחל</option>";
            x += "<option value='רבקה'>רבקה</option>";
            x += "<option value='משה'>משה</option>";
             /*for(i=0 ; i<teachersNames ; i++){
                x += "<option value='"+teachersNames[i]+"'>"+teachersNames[i]+"</option>";
             }
             x += "</select>";
             */
            x += "</select>";
            document.getElementById('ifr').contentWindow.document.getElementById("teacherDate").innerHTML = x;
            
        }
        else{
            document.getElementById('ifr').contentWindow.document.getElementById("teacherDate").style.display ="none";
        
        }
         document.getElementById('ifr').contentWindow.document.getElementById("year").innerHTML = "";
        for(i=0 ; i<50 ; i++){
            document.getElementById('ifr').contentWindow.document.getElementById("year").innerHTML += "<option value='"+              (2016+i)+"'>"+(2016+i)+"</option>;";
        }
    }
    
    
    document.getElementById('mainPage').style.display="none";
    document.getElementById('framePart').style.display="inline";
    document.getElementById('fillHours').style.display="none";
}

function userQuery(id){
    var loc= "userdetails.html";
    document.getElementById('ifr').setAttribute("src",loc);
    document.getElementById('mainPage').style.display="none";
    document.getElementById('framePart').style.display="inline";
    document.getElementById('fillHours').style.display="none";
}

function controlPanel(id){
    var loc= "/update";
    document.getElementById('framePart').innerHTML = " <center><iframe id='ifr' src='"+loc+"' ></iframe></center>";
    window.frames[0].onload = function(){
        if(id){
            //alert(document.getElementById('ifr').contentWindow.document.getElementById('adminPrev').style.display);
            document.getElementById('ifr').contentWindow.document.getElementById('adminPrev').style.display="none";
        }
    }
    document.getElementById('mainPage').style.display="none";
    document.getElementById('framePart').style.display="inline";
    document.getElementById('fillHours').style.display="none";
}

function uncheckAll(){
    
    
    var x1 = (document.getElementById("adminP"));
    var x2 = (document.getElementById("teacherP"));
    var x3 = (document.getElementById("studentP"));
    var x4 = (document.getElementById("schT"));
    x1.checked = false;
    x2.checked = false;
    x3.checked =false;
    x4.checked =false;
    
    
    x1.value=x2.value=x3.value=x4.value="0";
    
}

function checkBox(){
    var x1 = (document.getElementById("adminP").value)=="1";
    var x2 = (document.getElementById("teacherP").value)=="1";
    var x3 = (document.getElementById("studentP").value)=="1";
    
    var cb1;
    if((x1 && x2) || (x2 && x3) || (x1 && x3))
        cb1 = "f";
    else
        cb1 = "t";
    return cb1;
}

function backToMain(){
    parent.document.getElementById("framePart").style.display = "none";
    parent.document.getElementById("mainPage").style.display = "block";
}

function inputHours(){
       document.getElementById("framePart").style.display = "none";
        document.getElementById("mainPage").style.display = "none"; 
        document.getElementById("fillHours").style.height = "500px"
        document.getElementById("fillHours").style.display = "inline"; 
}

function disableInput(id){
    document.getElementById(id).disabled=true;
    document.getElementById(id).style.display="none";
    document.getElementById(id).parentElement.style.display="none";
}
function reCheckMe(id){
    document.getElementById(id).checked = true;
    if(id=="teacherP"){
        document.getElementById("pervs").style.display="inline-block";
        var x = document.getElementsByClassName("myRadio");
        var i;
        for(i=0 ; i<x.length ; i++){
            if(x[i].id!="sch")
                x[i].style.display="none";
        }
        
    }
    else if(id=="studentP"){
        disableInput("username");
        disableInput("password");
    }
    checkMe(id);
}
function checkMe(id){

    if(document.getElementById(id).checked){
        document.getElementById(id).value="1";
    }
    else
        document.getElementById(id).value="0";
        
    

    
}


function checkForm(){
    var checkBox =false;
    alert(document.getElementById("adminP").value +" "+document.getElementById("teacherP").value+" "+document.getElementById("studentP").value);
    if(document.getElementById("oldPassword") && document.getElementById("oldPassword").value.length==0){
        document.getElementById("oldPassword").style.borderColor="red";
        alert("אנא הכנס את הסיסמה הישנה");
        return false;
    }
    
    if(document.getElementById("username") && !document.getElementById("username").disabled ){
        var english = /^[A-Za-z0-9]*$/;
        var x1 = document.getElementById("username").value;
        if(x1.length<6){
            document.getElementById("username").style.borderColor="red";
            alert(" שם משתמש חייב להכיל שישה תוים או יותר")
            return false;
        }
        else if(!english.test(x1)){
            document.getElementById("username").style.borderColor="red";
            alert("אנא הכנס שם משתמש באנגלית ומספרים בלבד")
            return false;
        }
        else
            document.getElementById("username").style.borderColor="lightGreen";
    }
    if(document.getElementById("password") && !document.getElementById("password").disabled){
        var english = /^[A-Za-z0-9!@#$%&]*$/;
        x1 = document.getElementById("password").value;
        if(x1.length<6){
            document.getElementById("password").style.borderColor="red";
            alert(" סיסמה חייבת להכיל שישה תוים או יותר")
            return false;
        }
        else if(!english.test(x1)){
            document.getElementById("password").style.borderColor="red";
            alert("אנא סיסמא באנגלית, תווים מיוחדים ומספרים בלבד")
            return false;
        }
        else
            document.getElementById("password").style.borderColor="lightGreen";
    }
    if(document.getElementById("firstName")){
        var english = /^[A-Za-z ]*$/;
        var hebrew = /^[א-ת]*$/;
        var x1 = document.getElementById("firstName").value;
        if(x1.length<2){
            document.getElementById("firstName").style.borderColor="red";
            alert(" שם פרטי חייב להכיל שני תוים או יותר")
            return false;
        }
        else if((english.test(x1)) || (!english.test(x1) && !hebrew.test(x1))){
            alert("אנא הכנס שם פרטי באנגלית");
            document.getElementById("firstName").style.borderColor="red";
            return false;
        }
        else
            document.getElementById("firstName").style.borderColor="lightGreen";
    }
    if(document.getElementById("lastName")){
        var x1 = document.getElementById("lastName").value;
        if(x1.length<2){
            alert(" שם משפחה חייב להכיל שני תוים או יותר");
            document.getElementById("lastName").style.borderColor="red";
            return false;
        }
        else if((english.test(x1)) || (!english.test(x1) && !hebrew.test(x1))){
            alert("אנא הכנס שם משפחה באנגלית");
            document.getElementById("lastName").style.borderColor="red";
            return false;
        }
        else
            document.getElementById("lastName").style.borderColor="lightGreen";
    }
    if(document.getElementById("email")){
        var x1 = document.getElementById("email").value;
        var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        if(!re.test(x1)){
            document.getElementById("email").style.borderColor="red";
            alert("כתובת דואר אלקטרוני אינה תקינה");
            return false;
        }
        else
            document.getElementById("email").style.borderColor="lightGreen";
    }
    if(document.getElementById("phone")){
        var number = /^[0-9]*$/;
        if(document.getElementById("phone").value.length < 9){
            document.getElementById("phone").style.borderColor="red";
                alert("מספר טלפון קצר מדי");
                return false;
        }
        else if(!number.test(document.getElementById("phone").value)){
            document.getElementById("phone").style.borderColor="red";
                alert("מספר טלפון מכיל תוים לא חוקיים");
                return false;
        }
        else
            document.getElementById("phone").style.borderColor="lightGreen"; 
    }
    if(document.getElementById("city")){
        var english = /^[A-Za-z ]*$/;
        var hebrew = /^[א-ת]*$/;
        var x1 = document.getElementById("city").value;
        if(x1.length<2){
            document.getElementById("city").style.borderColor="red";
            alert(" שם העיר חייב להכיל שני תוים או יותר")
            return false;
        }
        else if((english.test(x1)) || (!english.test(x1) && !hebrew.test(x1))){
            alert("אנא הכנס שם עיר באנגלית");
            document.getElementById("city").style.borderColor="red";
            return false;
        }
        else
            document.getElementById("city").style.borderColor="lightGreen";
    }
    if(checkBox){
         document.getElementById("adminP").checked = true;
        document.getElementById("teacherP").checked = true;
        document.getElementById("studentP").checked = true;
        document.getElementById("schT").checked = true;
    }
}