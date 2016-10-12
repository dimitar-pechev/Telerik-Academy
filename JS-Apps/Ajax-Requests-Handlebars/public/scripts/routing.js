import { data } from 'data'
import { templateLoader } from 'template-loader'

var router = (() => {
    var navigo;

    function init() {
        navigo = new Navigo(null, false);

        navigo
            .on('#', () => {
                $('#content').html('')
            })
            .on('/threads/:id', (params) => {
                let threadId = params.id;

                Promise.all([data.threads.get(), templateLoader.get('threads'),
                    data.threads.getById(threadId), templateLoader.get('messages')])
                    .then(([threadsData, threadsTemplate, singleThreadData, messagesTemplate]) => {
                        let threadsHtml = threadsTemplate(threadsData),
                            messageHtml = messagesTemplate(singleThreadData),
                            html = threadsHtml + messageHtml;

                        $('#content').html(html);
                    })
                    .catch(console.log);
            })
            .on('/threads', () => {
                Promise.all([data.threads.get(), templateLoader.get('threads')])
                    .then(([data, template]) => {
                        let html = template(data);
                        $('#content').html(html);
                    })
                    .catch(console.log);
            })
            .on('/gallery', () => {
                Promise.all([data.gallery.get(), templateLoader.get('gallery')])
                    .then(([data, template]) => {
                        let html = template(data);
                        $('#content').html(html);
                    })
                    .catch(console.log);
            })
            .resolve();
    }

    function goto(location) {
        navigo.navigate(location);
    }

    return {
        init,
        goto
    }
})();

export { router }