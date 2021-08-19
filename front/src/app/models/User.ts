export class User{
    private _id: number;
   
    private _lastName: string;
   
    private _firstName: string;
    
    private _email: string;

    private _password: string;

constructor(){
    
}


public get id(): number {
    return this._id;
}
public set id(value: number) {
    this._id = value;
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
public get Email(): string {
    return this._email;
}
public set Email(value: string) {
    this._email = value;
}
public get Password(): string {
    return this._password;
}
public set Password(value: string) {
    this._password = value;
}

}