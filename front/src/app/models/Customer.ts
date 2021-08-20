import { User } from "./User";

export class Customer extends User{

    private _BirthdayDate: Date;


constructor(){
super()
}

public get BirthdayDate(): Date {
    return this._BirthdayDate;
}
public set BirthdayDate(value: Date) {
    this._BirthdayDate = value;
}

}