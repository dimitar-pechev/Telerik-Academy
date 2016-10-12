var popup = document.getElementById('popup');
    popup.style.opacity = 1;

var redirection = new Promise((resolve) => {
    setInterval(() => {
        popup.style.opacity -= 0.1;
    }, 200);
    setTimeout(() => {
        resolve('https://www.facebook.com');
    }, 2000);

});

redirection
    .then((url) => {
        window.location = url;
    });