import { Usuario } from "../../shared/usuario.model";
import { Component, OnInit } from "@angular/core";
import { UsuarioService } from "src/app/shared/usuario.service";
import { ToastrService } from "ngx-toastr";

@Component({
  selector: "app-usuario-list",
  templateUrl: "./usuario-list.component.html",
  styleUrls: ["./usuario-list.component.css"]
})
export class UsuarioListComponent implements OnInit {
  constructor(private service: UsuarioService, private toastr: ToastrService) {}

  ngOnInit() {
    this.service.refreshList();
  }

  resetForm() {
    this.service.formData = {
      id: "",
      nome: "",
      cpf: "",
      dataNascimento: "",
      estado: "",
      cidade: "",
      email: ""
    };
  }

  populateForm(Usuario: Usuario) {
    Usuario.dataNascimento = this.parseDate(Usuario.dataNascimento);
    this.service.formData = Object.assign({}, Usuario);
  }

  parseDate(dateString: string): string {
    if (dateString) {
      return new Date(dateString).toISOString().split("T")[0];
    }
    return null;
  }

  onDelete(id: number) {
    if (confirm("Deseja apagar o registro ?")) {
      this.service.deleteUsuario(id).subscribe(res => {
        this.service.refreshList();
        this.toastr.warning("Registro apagado sucesso.", "Informação");
        this.resetForm();
      });
    }
  }
}
