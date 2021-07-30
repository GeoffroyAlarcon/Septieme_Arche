import { Author } from "./author";
import { Item } from "./item";
import{Publishing} from"./publishing"
export class Book extends Item{
    private _isDigital: boolean;

    private _isbn: string;
   
    private _format: string;
 
    private _weight: number;
 
    private _numberOfPages: number;
  

    private _title: string;
  
    private _authors: Author[];

    private _resume: string;
  
    private _bookGenres: Array<string>;
    private _publishing: Publishing;
  

constructor(isbn:string,title:string,authors:Author[],price:number,clickNumber:number, stock:number,numberSalesItem:number,image:string,bookGenres: Array<string>,resume:string,numberOfPages:number,format:string,weight:number,publishing:Publishing,id:number){
    super(id,'',price,clickNumber,stock,numberSalesItem,image)
this._isbn = isbn;
this._title = title;
this._authors = authors;
this._bookGenres = bookGenres;
this._resume=resume;
this._numberOfPages=  numberOfPages;
this._format = format;
this._weight = weight;
this._publishing=publishing
}

 public get format(): string {
    return this._format;
}
public set format(value: string) {
    this._format = value;
}
public get isbn(): string {
    return this._isbn;
}
public set isbn(value: string) {
    this._isbn = value;
}
public get title(): string {
    return this._title;
}
public set title(value: string) {
    this._title = value;
    
}
public get weight(): number {
    return this._weight;
}
public set weight(value: number) {
    this._weight = value;
}

public get authors(): Author[] {
    return this._authors;
}
public set authors(value: Author[]) {
    this._authors = value;
}
public get resume(): string {
    return this._resume;
}
public set resume(value: string) {
    this._resume = value;
}
public get bookGenres(): Array<string> {
    return this._bookGenres;
}
public set bookGenres(value: Array<string>) {
    this._bookGenres = value;
}
public get publishing(): Publishing {
    return this._publishing;
}
public set publishing(value: Publishing) {
    this._publishing = value;
}
public get numberOfPages(): number {
    return this._numberOfPages;
}
public set numberOfPages(value: number) {
    this._numberOfPages = value;
}
public get isDigital(): boolean {
    return this._isDigital;
}
public set isDigital(value: boolean) {
    this._isDigital = value;
}
}