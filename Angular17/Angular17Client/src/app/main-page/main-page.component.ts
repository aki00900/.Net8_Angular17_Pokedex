import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../material/material.module';  
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { ServiceService } from '../services/service.service';
import { PopupComponent } from './popup/popup.component';

@Component({
  selector: 'app-main-page',
  standalone: true,
  imports: [CommonModule, MaterialModule],
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.scss']  // Corrected property name
})

export class MainPageComponent implements OnInit{
  pokemonData: any = {}
  datatSource: any = []
  listofSprites: string[] = ["https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/376.png",
                            "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/248.png",
                            "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/701.png",
                            "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/6.png",
                            "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/560.png",
                            "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/466.png",
                            "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/150.png",
                            "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/151.png",
                            "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/384.png",
                            "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/383.png",
                            "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/382.png",
                            "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/249.png",
                            "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/250.png",
                            "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/483.png",
                            "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/484.png",
                            "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/487.png"
                            ]
  dataSource = new MatTableDataSource(this.pokemonData);

  displayedColumns: string[] = ['Name', 'Picture', 'Type', 'PokedexNumber', 'Region', 'popup'];

  constructor(private service: ServiceService, public dialog: MatDialog){
    this.dataSource = new MatTableDataSource();
  }

  ngOnInit(): void {
    this.getAllPokemonData()
  }

  getAllPokemonData(): void {
    this.service.getAllPokemonData().subscribe({
      next: (res: any) => {
        console.log(res, "the pokemon data from API");
        this.pokemonData = res
        let cnt = 0
        this.pokemonData.map((pokemon: any) => {
          // Use the 'picture' property directly as 'frontImg'
          let imgUrl = this.listofSprites[cnt]
          cnt++
          return  pokemon.frontImg = imgUrl
          
        });
        console.log('pokemonObj', this.pokemonData);
        this.dataSource.data = this.pokemonData;
      },
      error: (error: any) => {
        console.error("Error fetching Pokémon data:", error);
      }
    })
  }

  openPopup(pokemon: any): void {
    // Make sure to fetch any additional data if needed
    this.service.getPokemonData(pokemon.pokedexNumber).subscribe({
      next: (res: any) => {
        const dialogConfig = new MatDialogConfig();
        dialogConfig.autoFocus = true;
        dialogConfig.width = '700px';
        dialogConfig.height = '700px';
        dialogConfig.data = {
          pokemon: res
        };

        if (this.dialog.openDialogs.length === 0) {
          const dialogRef = this.dialog.open(PopupComponent, dialogConfig);
          dialogRef.afterClosed().subscribe(result => {
            console.log(`Dialog result: ${result}`);
          });
        }
      }
    })
  }

}
