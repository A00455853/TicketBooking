var BookedSeats = [];
var Rows = ["A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M"];
var Columns = 15;
var TotalSeats = Rows.length * Columns;

function convertIntToSeatNumbers(seats) {
    var bookedSeats = "";
    _.each(seats, function(seat) {
        var row = Rows[parseInt(parseInt(seat) / 12)];
        var column = parseInt(seat) % 12;
        if (column == 0) {
            column = 12;
        }
        if (_.indexOf(seats, seat) == seats.length - 1) {
            bookedSeats = bookedSeats + row + column;
        } else {
            bookedSeats = bookedSeats + row + column + ",";
        }
    });
    return bookedSeats;
}

var InitialView = Backbone.View.extend({
    events: {
        "click #continueBooking": "submitForm"
    },
    submitForm: function() {
        var seatsBooked = JSON.parse(localStorage.getItem('seatsBooked'));
        var seatsAvailable = TotalSeats;
        var selectedNumberOfSeats = $('#seats').val();
        if (seatsBooked != null)
            seatsAvailable = TotalSeats - seatsBooked.length;
        if (!$('#name').val()) {
            $(".message").html("Please select any movie");
        } else if (!selectedNumberOfSeats) {
            $(".message").html("Please select seats");
        } else if (parseInt(selectedNumberOfSeats) > seatsAvailable) {
            $(".message").html("You can only select " + seatsAvailable + " seats")
        } else {
            $(".message").html("");
            screenUI.showView();
        }
    }
});
var initialView = new InitialView({
    el: $('.bookingTicket')
});

var ScreenUI = Backbone.View.extend({
    events: {
        "click .empty-seat,.booked-seat": "toggleBookedSeat",
        "click #confirmSelection": "bookTickets"
    },
    initialize: function() {
        var tableheaderTemplate = _.template($("#displayTickets").html());
        var tableBodyTemplate = _.template($("#displaybodyTickets").html());
        var data = {
            "rows": Rows,
            "columns": Columns
        };
        $("#screen-head").after(tableheaderTemplate(data));
        $("#screen-body").after(tableBodyTemplate(data));
    },
    hideView: function() {
        $(this.el).hide();
    },
    showView: function() {
        $(this.el).show();
    },
    toggleBookedSeat: function(event) {
        var id = "#" + event.currentTarget.id;
        if ($(id).attr('class') == 'empty-seat' && BookedSeats.length < $('#seats').val()) {
            BookedSeats.push(id.substr(1));
            $(id).attr('src', 'img/booked.png');
            $(id).attr('class', 'booked-seat');

        } else if ($(id).attr('class') == 'booked-seat') {
            BookedSeats = _.without(BookedSeats, id.substr(1));
            $(id).attr('src', 'img/empty-seat.png');
            $(id).attr('class', 'empty-seat');
        }
    },
    updateTicketInfo: function() {
        var bookedSeats = convertIntToSeatNumbers(BookedSeats);
        $("#soldMessage").append("<tr><td>" + $('#name').val() + "</td><td>" + $('#seats').val() + "</td><td>" + bookedSeats + "</td></tr>");
    },
    bookTickets: function() {
        if (BookedSeats.length == parseInt($('#seats').val())) {
            $(".message").text("");
            var seatsBooked = JSON.parse(localStorage.getItem('seatsBooked')) || [];
            _.each(BookedSeats, function(bookedSeat) {
                seatsBooked.push(bookedSeat);
            });
            var identifySeats = JSON.parse(localStorage.getItem('identifySeats')) || {};
            identifySeats[$('#name').val()] = BookedSeats;
            localStorage.setItem('identifySeats', JSON.stringify(identifySeats));
            localStorage.setItem('seatsBooked', JSON.stringify(seatsBooked));
            this.updateTicketInfo();
            window.location.reload();
        } else {
            $(".message").html("Please select exactly " + $('#seats').val() + " seats");
        }
    },
});

var screenUI = new ScreenUI({
    el: $('.ticketBox')
});
screenUI.hideView();

var TicketInfo = Backbone.View.extend({
    initialize: function() {
        var items = [];
        var json = JSON.parse(localStorage.getItem('identifySeats'));
        if (json != null) {
            _.each(json, function(key, value) {
                var name = value;
                var number = key.length;
                var bookedSeats = convertIntToSeatNumbers(key);
                items.push({
                    names: name,
                    numbers: number,
                    seats: bookedSeats
                });
            });
            var data = {
                "items": items
            };
            var ticketInfoBody = _.template($("#ticketMessage").html());
            $("#soldMessage").html(ticketInfoBody(data));
        }
    }
});

var ticketInfo = new TicketInfo({
    el: $('.table-responsive')
});