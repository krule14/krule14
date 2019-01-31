$(document).ready(function () {

    var id = document.getElementById("iid").value;
    //var query = window.location.search.substring(0);
    //console.log(query);
    //console.log(id);

    var ajax_call = function () {
        //your jQuery ajax code
        $.ajax({
            type: 'GET',
            dataType: 'json',
            url: '/Bids/BidFinder',
            data: { 'id': id },
            success: tableBids,
            error: showError
        });

    };

    function tableBids(data) {
       
        if (data !== null) {
            $.each(JSON.parse(data), function (key, item) {

                var bidData = '<tr><td>' + item.Buyer + '</td ><td>$' + item.Price.toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,') + '</td></tr>';
                $('returnTable').find('bids').append(bidData);

            });

        }
    }

    function showError(){
        $('error').append("err");
    }

    var interval = 1000 * 5; 

    window.setInterval(ajax_call, interval);

});