import { Customer } from "./Customer";
import { Item } from "./item";
import { LineItemOrder } from "./lineItemOrder";

export class Order {
    id: number;
    dateOrder: Date;
    Items: LineItemOrder[];
    customr: Customer;

}