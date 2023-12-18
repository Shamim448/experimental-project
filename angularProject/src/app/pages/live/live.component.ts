import { Component, OnInit } from '@angular/core';
import { DataCallService } from '../../services/data-call.service';
import { CommonModule } from '@angular/common';
import { IliveMatch } from '../../model/ilive-match';
import { MatchCardComponent } from "../../components/match-card/match-card.component";

@Component({
    selector: 'app-live',
    standalone: true,
    templateUrl: './live.component.html',
    styleUrl: './live.component.css',
    imports: [CommonModule, MatchCardComponent]
})
export class LiveComponent implements OnInit{


  liveMatch:IliveMatch[] = [];

  constructor(private _liveMatches: DataCallService){

  }
  ngOnInit(): void {
    this.liveMatch = this._liveMatches.getLiveMatch();
    console.log(this.liveMatch);
  }
}
