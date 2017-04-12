var popup = document.getElementById('popup'),
    mask = document.getElementById('page-mask'),
    popup = document.getElementById('popup'),
    classHidden = 'hidden';

var redirection = new Promise((resolve) => {
    setTimeout(() => {
        resolve('https://www.facebook.com');
    }, 3000);
});

document.getElementById('btn-facebook').onclick = () => {
    mask.classList.remove(classHidden);
    popup.classList.remove(classHidden);

    redirection
        .then((url) => {
            window.location = url;
        });
};
