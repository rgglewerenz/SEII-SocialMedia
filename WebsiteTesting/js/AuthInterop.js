class AuthController {


  constructor() {
    // Set the base URL for the API
    this.baseUrl = "https://localhost:7122/api/Auth";
	this.userAuthData = null;

	// Retrieve the login information from localStorage
	const userObj = localStorage.getItem('userObj');

	if(userObj == null){
		return;
	}

	this.userAuthData = JSON.parse(userObj);

  }

  // Authenticate user
  authenticateUser(email, password, onsucess) {
    $.ajax({
      url: `${this.baseUrl}/AuthenticateUser`,
      method: "GET",
      data: { email: email, password: password },
      success: function(data) {
        console.log(data);
		this.userAuthData = data;
		localStorage.setItem('userObj', JSON.stringify(data));
		onsucess();
      },
      error: function(xhr, textStatus, errorThrown) {
        if(errorThrown == "Internal Server Error"){
          console.error(getInternalServerErrorString(xhr));
        }
        else{
          console.error("Unknown error: ", errorThrown, xhr)
        }
      }
    });
  }
}

var _authController = new AuthController();


//This handles the user's credentials
window.onload = function () {
	const currentPath = window.location.pathname;
	if(currentPath.includes("login.html")){
		return;
	}
	if(_authController.userAuthData == null){
		window.location.href = "/login.html";
	}
};