document.addEventListener('click', function (event) {
    const target = event.target;
    if (target.classList.contains('clickable')) {
        swapSections(target.parentElement.id);
    }
});

function swapSections(sectionId) {
    const currentSection = document.getElementById(sectionId);
    const previousSection = currentSection.previousElementSibling;

    if (previousSection && currentSection) {
        const tempHTML = currentSection.innerHTML;
        const tempClass = currentSection.classList[1];

        currentSection.innerHTML = previousSection.innerHTML;
        currentSection.classList.replace(currentSection.classList[1], previousSection.classList[1]);

        previousSection.innerHTML = tempHTML;
        previousSection.classList.replace(previousSection.classList[1], tempClass);
    }
}
