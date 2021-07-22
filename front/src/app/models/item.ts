
export class Item{
    private _name: string;
   private _priceExcludingTax: number;

   private _numberOfClicks: number;
   private _stock: number;
   private _numberOfSales: number;
   private _image: string;

constructor(name:string, PriceExcludingTax:number,numberOfClicks:number,stock:number,numberOfSales:number,image:string){
this._name = name;
    this._priceExcludingTax = PriceExcludingTax;
this._numberOfClicks=numberOfClicks;
this._stock=stock; 
this._numberOfSales = numberOfSales;
this._image = image;

}


public get stock(): number {
    return this._stock;
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