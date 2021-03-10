

function loadTablePhotos(items) {
    const table = document.getElementById("bodyPhotos");
    items.forEach(item => {
        let row = table.insertRow();
        let title = row.insertCell(0);
        title.innerHTML = item.title;
        let image = row.insertCell(1);
        image.innerHTML = '<img src="' + item.thumbnailUrl + '"/>';
        let comment = row.insertCell(2);
        comment.innerHTML = '<button id="' + item.id + '" class="btn btn-success" onclick="getComments(this)">Ver Comentarios</button>';
    });
}

function loadComments(items) {
    var div = document.getElementById("bodyModalComments");
    items.forEach(item => {
        div.innerHTML += '<div class="container">' +
            '<div class="row">' +
            '<div class="panel panel-default widget">' +
            '<div class="panel-body">' +
            '<ul class="list-group">' +
            '<li class="list-group-item">' +
            '<div class="row">' +
            '<div class="col-xs-10 col-md-11">' +
            '<div>' +
            '<div class="mic-info">' +
            'NOMBRE: <a href="#">' + item.name + '</a> E-MAIL: ' + item.email +
            '</div>' +
            '</div>' +
            '<div class="comment-text">' +
            item.body +
            '</div>' +
            '</div>' +
            '</div>' +
            '</li>' +
            '</ul>' +
            '</div>' +
            '</div>' +
            '</div>' +
            '</div>';

    });
}
