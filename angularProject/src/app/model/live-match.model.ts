import { IliveMatch } from "./ilive-match";

export class LiveMatch implements IliveMatch{
    index:number = 0;
    matchHeading: any = "";
    matchNo: string = "";
    matchLocation: string = "";
    batingTeam: string = "";
    score: string = "";
    bowlingTeam: string = "";
    bScore: string = "";
    status: string = "";
    // constructor syntax to easily initialize current object
	public constructor(init?:Partial<LiveMatch>) {
        Object.assign(this, init);
 }

}
