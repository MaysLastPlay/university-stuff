const clickHandler = () => {
    const div2 = document.getElementById('div2');
    div2.style.background = 'blue';
    div2.style.color = 'white'; 

    const lastOlItem = document.getElementById('lastBook');
    lastOlItem.style.color = 'blue';
    console.log("Styles is changed!");
};