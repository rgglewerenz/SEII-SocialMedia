async function getPostByID(postID) {
    const response = await fetch(baseUrl + `post/GetPostByID?postID=${postID}`);
    const data = await response.json();
    return data;
}

async function getRecentPosts(page_count = 0, page_size = 10) {
    const response = await fetch(baseUrl + `post/GetRecentPosts?page_count=${page_count}&page_size=${page_size}`);
    const data = await response.json();
    return data;
}

async function createPost(caption, image_url, userID) {
    const response = await fetch(baseUrl + `post/CreatePost`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            Caption: caption,
            ImageURL: image_url,
            UsertID: userID
        })
    });
    const data = await response.json();
    return data;
}

async function editPost(caption, image_url, postID) {
    const response = await fetch(baseUrl + `post/EditPost`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            Caption: caption,
            ImageURL: image_url,
            PostID: postID
        })
    });
    const data = await response.json();
    return data;
}

async function deletePost(postID) {
    const response = await fetch(baseUrl + `post/DeletePost?postID=${postID}`, {
        method: "DELETE"
    });
    const data = await response.json();
    return data;
}

