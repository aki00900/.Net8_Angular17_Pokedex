import { Component, Inject } from '@angular/core';
import {
  MAT_DIALOG_DATA, MatDialogContent, MatDialogModule, MatDialogTitle
}from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-popup',
  standalone: true,
  imports: [CommonModule, MatDialogTitle, MatDialogContent, MatButtonModule, MatDialogModule],
  templateUrl: './popup.component.html',
  styleUrl: './popup.component.scss'
})
export class PopupComponent {
  constructor (@Inject (MAT_DIALOG_DATA) public data: {pokemon : any}) {}
  showBackShiny:boolean = false
  showFrontShiny:boolean  = false
    ngOnInit(){
    console.log(this.data.pokemon, 'passed in values')
    //this.data.pokemon.moves = []
    }
    
  setBackShiny(){
    this.showBackShiny = true
  }
  hideBackShiny(){
    this.showBackShiny = false
  }

  setFrontShiny(){
    this.showFrontShiny = true
  }
  hideFrontShiny(){
    this.showFrontShiny = false
  }
}

