import * as requester from 'requester';

function createEvent(title, description, date, category, users) {
    let body = {
        title,
        description,
        date,
        category,
        users
    };
    
    return requester.postJSON('/api/events', body);
}

function getEvents() {
    return requester.getJSON('/api/events');
}

export { createEvent, getEvents };