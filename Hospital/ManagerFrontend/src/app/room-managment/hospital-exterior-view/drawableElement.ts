export class DrawableElement {
    idElement: string;
    name: string;
    x: number;
    y: number;
    width: number;
    height: number;
    type: string;

    constructor(idElement: string, name: string, x: number, y: number, width: number, height: number, type: string ) {
        this.idElement = idElement;
        this.name = name;
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
        this.type = type;
    }



}