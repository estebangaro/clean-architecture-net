import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import {MatTableModule} from '@angular/material/table';
import {MatProgressBarModule} from '@angular/material/progress-bar';
import { Observable } from 'rxjs';

interface SoccerTeamEntity {
  name: string
}

interface StandingTeamInformation{
  position: number,
  points: number,
  team: SoccerTeamEntity
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  standingsUrl: string;
  standingTeamsInformation: StandingTeamInformation[];
  displayedColumns: string[] = ['rank', 'name', 'points'];

  constructor(private http: HttpClient) {
    this.standingsUrl = "soccerstatistics";
    this.standingTeamsInformation = [];
  }

  ngOnInit() {
    this.getHeroes().subscribe(standings => { 
      this.standingTeamsInformation = standings;
    });
  }

  /** GET heroes from the server */
  getHeroes(): Observable<StandingTeamInformation[]> {
    return this.http.get<StandingTeamInformation[]>(this.standingsUrl)
  }

}
