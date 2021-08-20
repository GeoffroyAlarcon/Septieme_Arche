
export class Item{
    private _name: string;
   private _priceExcludingTax: number;
    private _id: number;
   private _numberOfClicks: number;
   private _stock: number;
   private _numberOfSales: number;
   private _image: string;

constructor(){

}


public get stock(): number {
    return this._stock;
}

public get id(): number {
    return this._id;
}
public set id(value: number) {
    this._id = value;
}
public set stock(value: number) {
    this._stock = value;
}

public get image(): string {
    return this._image;
}
public set image(value: string) {
    this._image = value;
}
public get name(): string {
    return this._name;
}
    public get priceExcludingTax(): number {
        return this._priceExcludingTax;
    }
    public set priceExcludingTax(value: number) {
        this._priceExcludingTax = value;
    }
public set name(value: string) {
    this._name = value;
}
public get numberOfSales(): number {
    return this._numberOfSales;
}
public set numberOfSales(value: number) {
    this._numberOfSales = value;
}
public get numberOfClicks_1(): number {
    return this._numberOfClicks;
}
public set numberOfClicks_1(value: number) {
    this._numberOfClicks = value;
}
}