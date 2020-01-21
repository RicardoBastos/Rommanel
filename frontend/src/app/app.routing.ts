import { Routes, RouterModule } from "@angular/router";
import { HomeComponent } from "./home/home.component";
import { UsuariosComponent } from "./usuarios/usuarios.component";

const routes: Routes = [
  { path: "", component: HomeComponent },
  { path: "Usuario", component: UsuariosComponent },
  // otherwise redirect to home
  { path: "**", redirectTo: "" }
];

export const appRoutingModule = RouterModule.forRoot(routes);
