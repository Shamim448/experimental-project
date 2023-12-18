import { Injectable } from '@angular/core';
import { IliveMatch } from '../model/ilive-match';
import { LiveMatch } from '../model/live-match.model';

@Injectable({
  providedIn: 'root'
})
export class DataCallService {

  
  constructor() { }

  getLiveMatch() : IliveMatch[]{
    return[
      new LiveMatch({
        index:1,
        matchHeading: "New Zealand vs Pakistan",
        matchNo:"3rd ODI (D/N)",
        matchLocation:"Christchurch, December 18, 2023, New Zealand",
        batingTeam:"New Zealand",
        score:"251/8",
        bowlingTeam:"Pakistan",
        bScore:"(50 ov, T:252) 251/9",
        status:"Match tied (Pakistan (W) won the Super Over)"
      }),
      new LiveMatch({
        index:2,
        matchHeading: "B'desh U19 vs UAE U19",
        matchNo:"Final, Dubai (DSC)",
        matchLocation:"December 17, 2023, Asian Cricket Council Under-19s Asia Cup",
        batingTeam:"B'desh U19",
        score:"282/8",
        bowlingTeam:"UAE U19",
        bScore:"(24.5/50 ov, T:283) 87",
        status:"B'desh U19 won by 195 runs"
      }),
      new LiveMatch({
        index:3,
        matchHeading: "South Africa vs India",
        matchNo:"1st ODI",
        matchLocation:"Johannesburg, December 17, 2023, India tour of South Africa",
        batingTeam:"South Africa",
        score:"116",
        bowlingTeam:"India",
        bScore:"(16.4/50 ov, T:117) 117/2",
        status:"India won by 8 wickets (with 200 balls remaining)"
      })

    ]
  }
}
