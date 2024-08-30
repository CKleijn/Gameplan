self.addEventListener('push', (e) => {
    if (e.data) {
        const payload = e.data.json();

        e.waitUntil(
            self.registration.showNotification(payload.title, {
                body: payload.body
            })
        );
    }
})