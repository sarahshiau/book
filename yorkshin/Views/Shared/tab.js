const tabs = document.querySelectorAll('[data-tab-target]');
const tabContentContainer = document.getElementById('tabContent');

tabs.forEach(tab => {
    tab.addEventListener('click', async () => {
        const targetUrl = tab.dataset.tabTarget;
        const response = await fetch(targetUrl);
        const content = await response.text();
        
        tabContentContainer.innerHTML = content;

        tabs.forEach(tab => {
            tab.classList.remove('active');
        });

        tab.classList.add('active');
    });
});
