export class Author{
    private _lastName: string;
   
    private _firstName: string;
 
    private _resume: string;
    

constructor (lastName:string,firstName:string,resume:string){
this._lastName=lastName;
this._firstName=firstName;
this._resume= resume;
    
}

public get lastName(): string {
    return this._lastName;
}
public set lastName(value: string) {
    this._lastName = value;
}
public get firstName(): string {
    return this._firstName;
}
public set firstName(value: string) {
    this._firstName = value;
}
public get resume(): string {
    return this._resume;
}
public set resume(value: string) {
    this._resume = value;
}
}