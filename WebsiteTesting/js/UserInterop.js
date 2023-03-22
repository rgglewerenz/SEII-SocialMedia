class UserController {
  constructor() {
    // Set the base URL for the API
    this.baseUrl = "https://localhost:7122/api/User";
  }

  // Get all users
  getUsers() {
    $.ajax({
      url: `${this.baseUrl}/GetUsers`,
      method: "GET",
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

  // Get user by ID
  getUserById(userId) {
    $.ajax({
      url: `${this.baseUrl}/GetUserByID`,
      method: "GET",
      data: { userID: userId },
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

  // Create user
  createUser(email, password) {
    $.ajax({
      url: `${this.baseUrl}/CreateUser`,
      method: "POST",
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


var _userController = new UserController();