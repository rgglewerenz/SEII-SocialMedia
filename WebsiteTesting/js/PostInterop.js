class PostController {
  constructor() {
    // Set the base URL for the API
    this.baseUrl = "https://localhost:7122/api/Post";
  }

  // Get post by ID
  getPostById(postId) {
    $.ajax({
      url: `${this.baseUrl}/GetPostByID`,
      method: "GET",
      data: { postID: postId },
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

  // Get max post page count
  getMaxPostPageCount(pageSize) {
    $.ajax({
      url: `${this.baseUrl}/GetMaxPostPageCount`,
      method: "GET",
      data: { page_size: pageSize },
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

  // Get recent posts
  getRecentPosts(pageCount, pageSize) {
    $.ajax({
      url: `${this.baseUrl}/GetRecentPosts`,
      method: "GET",
      data: { page_count: pageCount, page_size: pageSize },
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

  // Create post
  createPost(caption, imageUrl, userId) {
    $.ajax({
      url: `${this.baseUrl}/CreatePost`,
      method: "POST",
      data: { caption: caption, image_url: imageUrl, userID: userId },
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

  // Edit post
  editPost(caption, imageUrl, postId) {
    $.ajax({
      url: `${this.baseUrl}/EditPost`,
      method: "POST",
      data: { caption: caption, image_url: imageUrl, postID: postId },
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

  // Delete post
  deletePost(postId) {
    $.ajax({
      url: `${this.baseUrl}/DeletePost`,
      method: "DELETE",
      data: { postID: postId },
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


var _postController = new PostController();
