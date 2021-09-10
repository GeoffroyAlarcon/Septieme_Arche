import { Author } from "./author";
import { Item } from "./item";
import { Publishing } from "./publishing"
export class Book extends Item {
    isDigital: boolean;
    isbn: string;
    format: string;
    weight: number;
    numberOfPages: number;
    title: string;
    authors: Author[];
    resume: string;
    bookGenres: Array<string>;
    publishing: Publishing;


    constructor() {
        super()

    }

}