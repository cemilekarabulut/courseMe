
function GetInstructers() {

    var x = document.getElementById("course").value
    var list1 = document.getElementById("ins");
    $.ajax({

        url: '/Course/getInstructor/' + x,
        data: { x: x },
        type: "POST",
        dataType: 'json',
        success: function (data) {
            $.each(data, function (i, item) {


                list1.options[i] = new Option(text = item.name, value = item.id);

            });
        }
    });
}
function toTable() {
    
    $.ajax({

        url: '/Course/showstudents/',

        type: "POST",
        dataType: 'json',
        success: function (data) {
            var x, y;
            document.getElementById("name").innerHTML = data[0].section_date;
            
            document.getElementById("course").innerHTML = data[0].course_name;
            document.getElementById("section").innerHTML = data[0].section_id;
            if (data[0].student_name != null) {
                $.each(data, function (i, item) {
                    if (item.midterm == -2) {
                        x = "";
                    }
                    else
                        x = item.midterm;
                    if (item.final == -2) {
                        y = "";
                    }
                    else
                        y = item.final;
                    $('<tr>').append(
                        $('<td>').text(i),
                        $('<td>').text(item.student_id),
                        $('<td>').text(item.student_name),
                        $('<td>').text(item.student_surname),

                        $('<td>').append('<p id="/' + i.toString() + '">' + x.toString() + '</p>'),
                        $('<td>').append("<input type='number' min='0' max='100' id='" + i.toString() + "' onchange='getGrade(this)'>"),
                        $('<td>').append('<p id="*' + i.toString() + '">' + y.toString() + '</p>'),
                        $('<td>').append("<input type='number' min='0' max='100' id='-" + i.toString() + "' onchange='getFinal(this)'>"),
                        $('<td>').append('<p id="+' + i.toString() + '" style="color:red;font-size:medium"></p>')).appendTo('#Table');




                });
            }
            displayImage();
        }
    });
}
var midterm = [];
var final = [];
function getGrade(ctl) {
    _row = $(ctl).parents("tr");
    var cols = _row.children("td");
    var  id= $(cols[1]).text();
    var i = $(cols[0]).text();
 
   
        if (document.getElementById(i).value != "") {
            if (midterm.find(fruit => fruit.id == id)==null) {
                midterm.push({ id: id, grade: document.getElementById(i).value });
            }
            else {
                midterm.splice(midterm.indexOf(midterm.find(fruit => fruit.id == id)), 1 );
                midterm.push({ id: id, grade: document.getElementById(i).value });

            }

        }
        else
            midterm.splice(midterm.indexOf(midterm.find(fruit => fruit.id == id)), 1);
    //$.ajax({

    //    url: '/Course/putDictionary/',
    //    data: { id: id, midterm:midterm },
    //    type: "POST"
      
    //});

  
}
function getFinal(ctl) {
    _row = $(ctl).parents("tr");
    var cols = _row.children("td");
    var id = $(cols[1]).text();
    var i = $(cols[0]).text();
   

    if (document.getElementById("-" + i).value != "") {
        if (final.find(fruit => fruit.id == id) == null) {
            final.push({ id: id, grade: document.getElementById("-" + i).value });;
        }
        else {
            final.splice(final.indexOf(final.find(fruit => fruit.id == id)), 1);
            final.push({ id: id, grade: document.getElementById("-" + i).value });

        }
        
    }
    else
        final.splice(final.indexOf(final.find(fruit => fruit.id == id)), 1);


}

function updateGrade() {
    var section = parseInt(document.getElementById("section").innerHTML);
    if (midterm != null || final != null) {
    $.ajax({

        url: '/Course/updateGrade/' + section,
        data: { section: section, midterm: midterm, final: final },
        type: "POST",
         success: function () {
            document.location.reload(true);
        }

    });
}
}
function pass_fail() {
    var sum = 0;
    var rowctr = $("#Table td").closest("tr").length;
    for (i = 0;i<rowctr ; i++) {
        if (document.getElementById("/" + i.toString()).innerHTML != "" && document.getElementById("*" + i.toString()).innerHTML != "") {
            sum += document.getElementById("/" + i.toString()).innerHTML * 4 / 10 + document.getElementById("*" + i.toString()).innerHTML * 6 / 10;
            if (document.getElementById("/" + i.toString()).innerHTML * 4 / 10 + document.getElementById("*" + i.toString()).innerHTML * 6 / 10 > 60) {
                document.getElementById("+" + i.toString()).innerHTML = "Passed" +", Letter Grade: " +letterGrade(document.getElementById("/" + i.toString()).innerHTML * 4 / 10 + document.getElementById("*" + i.toString()).innerHTML * 6 / 10);
            }
            else {
                document.getElementById("+" + i.toString()).innerHTML = "Failed" + ", Letter Grade: " +letterGrade(document.getElementById("/" + i.toString()).innerHTML * 4 / 10 + document.getElementById("*" + i.toString()).innerHTML * 6 / 10);
            }
        }
        else
            document.getElementById("+" + i.toString()).innerHTML = "Failed";
    }
    sum /= rowctr;
    $('<tr>').append(
        $('<td>').text(""),
        $('<td>').text(""),
        $('<td>').text(""),
        $('<td>').text(""),

        $('<td>').text(""),
        $('<td>').text(""),
        $('<td>').text(""),
        $('<td>').text(""),
        $('<td>').append('<p style="font-size:medium">Class Average: ' + sum.toString() + ' </p>')).appendTo('#Table');

}
function apply(){
    var section = parseInt(document.getElementById("section").innerHTML);
    $.ajax({

        url: '/Course/pass_fail/' + section,
        data: { section: section }
      

    });
    $("#applied").show();
}
function letterGrade(midterm) {
    var x;
    if (midterm > 89) {
        x = "AA";
    }
    else if (midterm > 84) {
        x = "BA";
    }
    else if (midterm > 79) {
        x = "BB";
    }
    else if (midterm > 74) {
        x = "CB";
    }
    else if (midterm > 69) {
        x = "CC";
    }
    else if (midterm > 64) {
        x = "DC";
    }
    else if (midterm > 59) {
        x = "DD";
    }
    else if (midterm > 49) {
        x = "FD";
    }
    else {
        x = "FF";
    }
    return x;
}
function displayImage() {
    var section = parseInt(document.getElementById("section").innerHTML);
    $.ajax({

        url: '/Course/displayImage/'+ section,
        data: { section: section },
        async: true,
     
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
       
            $("#image").attr("src", "data:image/jpg;base64," + data);
        }

    });
  
}
//function pass_fail() {
//    var str = "#a"
//    var numofstu = parseInt(document.getElementById("temp").innerHTML);

//    for (i = 0; i < numofstu; i++) {
//        $(str).show();

//        str += "a";
//    }
//    $("#average").show();

//}


//function pass_fail(button, model) {
//    var model = new UserViewModel(model);
//    var formRef = $(button).attr("data-ref")
//    $.ajax({

//        url: '/Course/pass_fail/' + model,
//        data: { model: model },
//        type: "POST",
//        error: function (req, status, error) {
//            // do something with error
//        }

//    });

//    function UserViewModel(model) {
//        this.Name = model.Name;
//        this.Role = model.Role;
//    }

//}