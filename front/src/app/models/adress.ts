export class Adress {
    
    private id:number;
    private _country: string;
    private _street: string;
    private _streetNumber: string;
    private _zipCode: string;
    private _phoneNumber: string;
    private _digitalcodeNumber: string;
    private _typeBuilding: string;
    constructor(){

    }
    public get country(): string {
        return this._country;
    }
    public set country(value: string) {
        this._country = value;
    }
    public get street(): string {
        return this._street;
    }
    public set street(value: string) {
        this._street = value;
    }
    public get zipCode(): string {
        return this._zipCode;
    }
    public set zipCode(value: string) {
        this._zipCode = value;
    }
    public get phoneNumber(): string {
        return this._phoneNumber;
    }
    public set phoneNumber(value: string) {
        this._phoneNumber = value;
    }
    public get digitalcodeNumber(): string {
        return this._digitalcodeNumber;
    }
    public set digitalcodeNumber(value: string) {
        this._digitalcodeNumber = value;
    }
    public get typeBuilding(): string {
        return this._typeBuilding;
    }
    public set typeBuilding(value: string) {
        this._typeBuilding = value;
    }
    public get streetNumber(): string {
        return this._streetNumber;
    }
    public set streetNumber(value: string) {
        this._streetNumber = value;
    }
}