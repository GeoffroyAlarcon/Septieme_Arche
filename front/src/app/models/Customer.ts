import { Adress} from "./adress";
import { User } from "./User";

export class Customer extends User{

    private _BirthdayDate: Date;
    private _DeliveryAdress: Adress; 

constructor(){
super()
}

public get BirthdayDate(): Date {
    return this._BirthdayDate;
}
public set BirthdayDate(value: Date) {
    this._BirthdayDate = value;
}
public get DeliveryAdress(): Adress {
    return this._DeliveryAdress;
}
public set DeliveryAdress(value: Adress) {
    this._DeliveryAdress = value;
}
}