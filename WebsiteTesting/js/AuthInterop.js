class AuthController {
  constructor() {
    // Set the base URL for the API
    this.baseUrl = "https://localhost:7122/api/Auth";
  }

  // Authenticate user
  authenticateUser(email, password) {
    $.ajax({
      url: `${this.baseUrl}/AuthenticateUser`,
      method: "GET",
      data: { email: email, password: password },
      success: function(data) {
        console.log(data)
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