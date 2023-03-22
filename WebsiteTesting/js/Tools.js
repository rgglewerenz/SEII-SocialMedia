function getInternalServerErrorString(xhr){
    var text = xhr.responseText;
    return text.split("\n")[0].split(": ")[1];
}