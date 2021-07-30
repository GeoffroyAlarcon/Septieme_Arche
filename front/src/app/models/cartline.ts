import { Item } from "./item";

export class CartLine  {
    private _amount: number;
   private _item: Item;
    constructor(){
    
    }
    public get amount(): number {
        return this._amount;
    }
    public set amount(value: number) {
        this._amount = value;
    } 
    public get item(): Item {
        return this._item;
    }
    public set item(value: Item) {
        this._item = value;
    }
    
}