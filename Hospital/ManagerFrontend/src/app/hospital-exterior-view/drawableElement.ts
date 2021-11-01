export class DrawableElement {
    id: number;
    name: string;
    x: number;
    y: number;
    width: number;
    height: number;
    type: string;

    constructor(id: number, name: string, x: number, y: number, width: number, height: number, type: string ) {
        this.id = id;
        this.name = name;
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
        this.type = type;
    }



}