const events = {};

module.exports = {
    publish(eventName, param) {
        if (events[eventName]) {
            events[eventName].forEach(callback => {
                callback(param);   
            })
        }
    },
    subscribe(eventName, callback) {
        //events[eventName] = events[eventName] || [];
        if (!events[eventName]) {
            events[eventName] = [];
        }
        events[eventName].push(callback);
    },
    unsubscribe(eventName, callback) {
        
    }
};