
let deedInput = document.getElementById("deedFile");
let audioInput = document.getElementById("audioFile");
let button = document.getElementById("submitButton");

button.disabled = true; //sets submit button state to disabled

deedInput.addEventListener("change", requireAudioFile);//change event handler for deed input
audioInput.addEventListener("change", requireDeedFile);//change event handler for audio file input


//function checks if audio file is empty, if so the submit button remains disabled, if not empty the button is enabled
function requireAudioFile() {
    if (document.getElementById("audioFile").value === "") {
        button.disabled = true; //button remains disabled
    }
    else {
        button.disabled = false; //submit button is enabled 
    }
}
//function checks if the deed file is empty, if so the submit button remains disabled, if not the button is enabled
function requireDeedFile() {
    if (document.getElementById("deedFile").value === "") {
        button.disabled = true; //submit button stays in disabled state
    }
    else {
        button.disabled = false;//submit button is enabled
    }
}

//change event handler for audio file input
document.getElementById("audioFile").addEventListener("change", validateAudioFile)
//function validates the audio file input 
//checks file extension validation for (.mp3, .mp4, .wav, .wave)
//checks file size validation currently set for 1GB 
function validateAudioFile() {
    const extensions = ['mp3', 'mp4', 'wav', 'wave'],
        size = 1073741824;//allow for 1GB?
    //separates files name and size from inidividual file
    const { name: fileName, size: fileSize } = this.files[0];
    const fileExt = fileName.split(".").pop();//splits and separates the file extension name
    //checks if the file extension meets requirements (.mp3/.MP4, .wav, .wave)  
    if (!extensions.includes(fileExt)) {
        alert("Only .mp3, .mp4, .wav, or .wave file extensions are allowed!");
        this.value = null;
    }
    //checks the file size limitation
    else if (fileSize > size) {
        alert("File is too big")
        this.value = null;
    }
}