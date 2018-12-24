function hidesShow(blockId, buttonId) {
    // get the clock
    var myBlock = document.getElementById(blockId);
    
    // get the current value of the clock's display property
    var displaySetting = myBlock.style.display;

    // also get the clock button, so we can change what it says
    var blockButton = document.getElementById(buttonId);

    // now toggle the clock and the button text, depending on current state
    if (displaySetting == 'block') {
        // clock is visible. hide it
        myBlock.style.display = 'none';
        // change button text
        blockButton.innerHTML = '+';
    }
    else {
        // clock is hidden. show it
        myBlock.style.display = 'block';
        // change button text
        blockButton.innerHTML = '-';
    }
}
function toggleBootstrap() {
    // get the clock
    var myBlock = document.getElementById('bootstrapCSSRef');

    // get the current value of the clock's display property
    var displaySetting = myBlock.style.display;

    // also get the clock button, so we can change what it says
    var blockButton = document.getElementById('bootButton');

    // now toggle the clock and the button text, depending on current state
    if (displaySetting == 'block') {
        // clock is visible. hide it
        myBlock.style.display = 'none';
        // change button text
        blockButton.innerHTML = '+';
    }
    else {
        // clock is hidden. show it
        myBlock.style.display = 'block';
        // change button text
        blockButton.innerHTML = '-';
    }
}
function toggleSelector() {
    // get the clock
    var myBlock = document.getElementById('Selector');

    // get the current value of the clock's display property
    var displaySetting = myBlock.style.display;

    // also get the clock button, so we can change what it says
    var blockButton = document.getElementById('selectorButton');

    // now toggle the clock and the button text, depending on current state
    if (displaySetting == 'block') {
        // clock is visible. hide it
        myBlock.style.display = 'none';
        // change button text
        blockButton.innerHTML = '+';
    }
    else {
        // clock is hidden. show it
        myBlock.style.display = 'block';
        // change button text
        blockButton.innerHTML = '-';
    }
}
function toggleBasicSelectors() {
    // get the clock
    var myBlock = document.getElementById('basicSelectors');

    // get the current value of the clock's display property
    var displaySetting = myBlock.style.display;

    // also get the clock button, so we can change what it says
    var blockButton = document.getElementById('basicSelectorButton');

    // now toggle the clock and the button text, depending on current state
    if (displaySetting == 'block') {
        // clock is visible. hide it
        myBlock.style.display = 'none';
        // change button text
        blockButton.innerHTML = '+';
    }
    else {
        // clock is hidden. show it
        myBlock.style.display = 'block';
        // change button text
        blockButton.innerHTML = '-';
    }
}
function togglePseudoclasses() {
    // get the clock
    var myBlock = document.getElementById('Pseudoclasses');

    // get the current value of the clock's display property
    var displaySetting = myBlock.style.display;

    // also get the clock button, so we can change what it says
    var blockButton = document.getElementById('PseudoclassesButton');

    // now toggle the clock and the button text, depending on current state
    if (displaySetting == 'block') {
        // clock is visible. hide it
        myBlock.style.display = 'none';
        // change button text
        blockButton.innerHTML = '+';
    }
    else {
        // clock is hidden. show it
        myBlock.style.display = 'block';
        // change button text
        blockButton.innerHTML = '-';
    }
}