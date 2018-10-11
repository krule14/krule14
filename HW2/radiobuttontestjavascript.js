var score=[0,0,0,0,0] //midorii, bakugo,todoroki, uraraka, asui 
var perc=[0,0,0,0,0]

/*
    @input index walue to determine which character gets a point
    Called by indevidual questions to keep score of which character
    a user is most like.
    The score is kept in an array whose indices correspond to a character. 
*/
function adder(index){
    score[index]=score[index]+1;
}
function addMulti(index1,index2){
    score[index1]=score[index1]+1;
    score[index2]=score[index2]+1;
}

/*
    helper method to getwinner, calculates which index
    has the highest score in the score array
*/
function getHighScoreIndex() {
    var highScoreIndex=0;
    var cur=0;
    for(cur; cur< score.length ;cur++){
        if(score[cur]>= score[highScoreIndex]){
            highScoreIndex=cur;
        }
    }
    return highScoreIndex;
    
  }
/*
  Called by submit button, inserts the name of the character 
  that the user is most like.  
*/
function getWinner(){
    var highScoreIndex=getHighScoreIndex();
    var winnerName="error";
    if(highScoreIndex==0){ winnerName= "MidUserTable"}
    if(highScoreIndex==1){ winnerName= "BakUserTable"}
    if(highScoreIndex==2){ winnerName= "TodUserTable"}
    if(highScoreIndex==3){ winnerName= "UrUserTable"}
    if(highScoreIndex==4){ winnerName= "AsuUserTable"}
    document.getElementById(winnerName).innerHTML = "You are most like this character";
}

function getRandomInt(max) {
    return Math.floor(Math.random() * Math.floor(max));
  }

function setRandPercentScore(){
    var index=0;
    var sum=0;
    for(index;index<=4;index++){
        sum= getRandomInt(100-sum);
        perc[index]=sum;
    }
    printRandPercentScore();
}
function printRandPercentScore(){
    document.getElementById("MidRandTable").innerHTML = " "+ perc[0] + "% of people were like Midoria";
    document.getElementById("BakRandTable").innerHTML = " "+ perc[1] + "% of people were like Bakugo";
    document.getElementById("TodRandTable").innerHTML = " "+ perc[2] + "% of people were like Todoroki";
    document.getElementById("UrRandTable").innerHTML =  " "+ perc[3] + "% of people were like Uraraka";
    document.getElementById("AsuRandTable").innerHTML = " "+ perc[4] + "% of people were like Asui";
}
function submitTest(){
    
}





