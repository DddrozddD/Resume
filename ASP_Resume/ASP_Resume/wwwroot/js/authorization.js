function RegistrationUser() {
    var email = $("#EmailForReg").val();
    var password = $("#PasswordForReg").val();
    var secondName = $("#SecondNameForReg").val();
    var firstName = $("#FirstNameForReg").val();
    var telephone = $("#TelephoneForReg").val();
    var town = $("#TownForReg").val();
    var country = $("#CountryForReg").val();
    var confirmPass = $("#ConfirmPassForReg").val();
    var login = $("#LoginForReg").val();
    var age = $("#AgeForReg").val();

    $.ajax({
        async: true,
        url: "/api/ApiAuthorization/RegUser",
        method: "POST",
        data: JSON.stringify({
            "Login": login,
            "Email": email,
            "SecondName": secondName,
            "FirstName": firstName,
            "Telephone": telephone,
            "Town": town,
            "Country": country,
            "Password": password,
            "ConfirmPass": confirmPass,
            "Age": age
        }),
        headers: {
            "content-type": "application/json; odata=verbose"
        },
        success: function (data) {
            if (data == null) {
                alert("Account registered. Please verify your email to use the site.")
                closeRegForm();
            }
            else {
                var errorStr = "Errors:"
                $.each(data, function (index, error) {
                    errorStr += error.code + ";"
                });
                alert(errorStr);
            }
            
        },
        error: function (error) {
            console.log(JSON.stringify(error));
        }
    });
   
}


function LoginUser() {


    var email = $("#EmailForLogIn").val();
    var password = $("#PasswordForLogIn").val();

    $.ajax({
        async: true,
        url: "/api/ApiAuthorization/LoginUser",
        method: "POST",
        data: JSON.stringify({
            "Email": email,
            "Password": password
        }),
        headers: {
            "content-type": "application/json; odata=verbose"
        },
        success: function (data) {
            if (data == null) {
                alert("Account login. Reset page.")
                closeLoginForm();
            }
            else {
                alert(data);
                
            }
           
        },
        error: function (error) {
            console.log(JSON.stringify(error));
        }
    });
}

function LogoutUser() {

$.ajax({
        async: true,
        url: "/api/ApiAuthorization/LogoutUser",
        method: "GET",
        headers: {
            "content-type": "application/json; odata=verbose"
        },
        success: function (data) {
            alert("Account logout. Reset page.")
        },
        error: function (error) {
            console.log(JSON.stringify(error));
        }
    });
}


function openRegForm() {
    document.getElementById("regForm").style.display = "block";
}

function closeRegForm() {
    document.getElementById("regForm").style.display = "none";
}

function openLoginForm() {
    document.getElementById("loginForm").style.display = "block";
}

function closeLoginForm() {
    document.getElementById("loginForm").style.display = "none";
}