const uri = 'api/TabularReasons';

let triangleObjects = [];
let drawnTriangles = [];
let drawnTextObjects = [];

let visualMultiplier = 10;
let fontSize = 20;

let lightBlue = '#5B9BD5';
let lightGrey = '#BCC3CA';
let white = '#FEFFFF';


function getAndDrawItems() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayItems(data))
        .catch(error => console.error('Unable to get items.', error));
}

function canvasMouseDown(options) {

    if (options.target) {
        var foundIdx = -1;

        if (options.target.type == 'text') {
            for (var i = 0; i < drawnTextObjects.length; i++)
                if (drawnTextObjects[i] == options.target) {
                    foundIdx = i;
                    break;
                }
        }
        else if (options.target.type == 'polygon') {
            for (var i = 0; i < drawnTriangles.length; i++)
                if (drawnTriangles[i] == options.target) {
                    foundIdx = i;
                    break;
                }
        }

        if (foundIdx != -1) {
            selectDrawnTriangle(foundIdx);
        }
    }
}

function selectDrawnTriangle(index) {
    var t = drawnTriangles[index];
    t.set({ strokeWidth: 3, stroke: 'yellow' });
    canvas.renderAll();
    canvas.setActiveObject(t);
}


function _displayItems(data) {
    canvas = new fabric.Canvas('myCanvas');
    canvas.hoverCursor = 'pointer';

    canvas.on('mouse:down', canvasMouseDown);

    console.log("how many times _displayItems");

    console.log(data);

    data.forEach(item => {

        var p1 = { x: item.v1.x * visualMultiplier, y: item.v1.y * visualMultiplier },
            p2 = { x: item.v2.x * visualMultiplier, y: item.v2.y * visualMultiplier },
            p3 = { x: item.v3.x * visualMultiplier, y: item.v3.y * visualMultiplier };

        var textLeft = (item.column % 2 == 0) ? p1.x + (p3.x - p1.x) / 2 : p1.x + (p3.x - p1.x) / 4;
        var textTop = (item.column % 2 == 0) ? p1.y + (p3.y - p2.y) / 4 : p2.y - (p2.y - p1.y) / 3;

        textLeft = Math.round(textLeft);
        textTop = Math.round(textTop);

        console.log(item.row+item.column + ": ");
        console.log(p1.x + " " + p1.y + ", " + p2.x + " " + p2.y + ", " + p3.x + " " + p3.y);
        console.log("textLeft: " + textLeft);
        console.log("textTop: " + textTop);

        var text = new fabric.Text(item.reason, { left: textLeft, top: textTop, fontSize: fontSize });
        text.setColor(white);
        text.lockMovementX = true;
        text.lockMovementY = true;
        text.lockRotation = true;
        text.lockScalingX = true;
        text.lockScalingY = true;

        var shape = new fabric.Polygon([p1, p2, p3]);
        shape.set('fill', lightBlue);
        shape.set({ strokewidth: 1, stroke: lightGrey });
        shape.perPixelTargetFind = true;
        shape.lockMovementX = true;
        shape.lockMovementY = true;
        shape.lockRotation = true;
        shape.lockScalingX = true;
        shape.lockScalingY = true;

        canvas.add(shape);
        canvas.add(text);

        drawnTriangles.push(shape);
        drawnTextObjects.push(text);

    });

    triangleObjects = data;
}
