$(document).ready(function () {


    $('#text-input').bind('keypress', function ( event )
    {

        if (event.which == 32) {

            keywordSearch();
            event.preventDefault;

        }

        function keywordSearch() {

            var userInput = $('#text-input').val();
            var latestWord = showLatest(userInput);

            if (!isInteresting(latestWord)) {
                $.ajax({
                    url: '/RequestLogs/Sticker',
                    type: 'GET',
                    data: { 'userInput': latestWord },
                    success: showResult,
                    error: errorReturn
                });
            } else {
                var str = latestWord;
                $('#returnView').append(" " + str);
                
            }
        }

        function showLatest(inputStr) {
            var strArray = inputStr.split(" ");
            

            return strArray[strArray.length - 1];
        }

        function isInteresting(word) {
            
            var popularWords = ['without', 'before', 'under', 'around', 'among', 'the', 'of', 'to', 'and', 'a', 'in', 'is', 'it', 'you', 'that', 'he', 'was', 'for', 'on', 'are', 'with', 'as', 'I', 'his', 'they', 'be', 'at', 'one', 'have', 'this', 'from', 'or', 'had', 'by', 'hot', 'word', 'but', 'what', 'some', 'we', 'can', 'out', 'other', 'were', 'all', 'there', 'when', 'up', 'use', 'your', 'how', 'said', 'an', 'each', 'she', 'which', 'do', 'their', 'time', 'if', 'will', 'way', 'about', 'many', 'then', 'them', 'write', 'would', 'like', 'so', 'these', 'her', 'long', 'make', 'thing', 'see', 'him', 'two', 'has', 'look', 'more', 'day', 'could', 'go', 'come', 'did', 'number', 'sound', 'no', 'most', 'people', 'my', 'over', 'know']; 


            var i;
            for (i = 0; i < popularWords.length; i++) {
                if (word == popularWords[i]) {
                    return true;
                    break;
                } 
            }
            return false;

        }

        function showResult(giphy) {

            var result = "";
            var giphyURL = giphy.data.images.fixed_height_still.url;

            result += "<img src='" + giphyURL + "' width=150px, height=150px/>";

            $('#returnView').append(result);

        }

        function errorReturn() {
            $('#returnView').append("!Error!");
        }

        $('#clearBtn').click(function () {
            location.reload();
        });



    });

});