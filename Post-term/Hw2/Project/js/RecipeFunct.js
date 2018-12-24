function addIngredient() {
    var ingred = document.getElementById("ingred").value;
    var unit = document.getElementById("unit").value;
    var table = document.getElementById("Ingredient_Table");
    if (validIngred(ingred, unit)) {
        var row = table.insertRow(-1);
        var cell1 = row.insertCell(-1);
        var cell2 = row.insertCell(-1);
        cell1.innerHTML = unit;
        cell2.innerHTML = ingred;
    } 
}

function validIngred(ingred, unit) {
    if (((ingred != null) && (unit != null)) && ((ingred != "") && (unit != ""))) {
        return true;
    } else {
        return false;
    }
}

function addInstructions() {
    var instruct = document.getElementById("instruct").value;
    var table = document.getElementById("Instruction_Table");
    if (validInstruct(ingred, unit)) {
        var row = table.insertRow(-1);
        var cell1 = row.insertCell(-1);
        cell1.innerHTML = instruct;
    }
}

function validInstruct(instruct) {
    if ((instruct != null)  && (instruct != "") ) {
        return true;
    } else {
        return false;
    }
}
