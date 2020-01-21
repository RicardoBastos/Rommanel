import { Component, OnInit } from "@angular/core";
import { NgForm } from "@angular/forms";
import { ToastrService } from "ngx-toastr";
import { UsuarioService } from "src/app/shared/usuario.service";

@Component({
  selector: "app-usuario",
  templateUrl: "./usuario.component.html",
  styleUrls: ["./usuario.component.css"]
})
export class UsuarioComponent implements OnInit {
  constructor(private service: UsuarioService, private toastr: ToastrService) {}

  ngOnInit() {
    this.resetForm();
  }

  resetForm(form?: NgForm) {
    if (form != null) {
      form.resetForm();
    }

    this.service.formData = {
      id: "",
      nome: "",
      cpf: "",
      email: "",
      cidade: "",
      estado: "",
      dataNascimento: ""
    };
  }

  parseDate(dateString: string): string {
    if (dateString) {
      return new Date(dateString).toISOString().split("T")[0];
    }
    return null;
  }

  onSubmit(form: NgForm) {
    //validar email
    if (!this.validarEmail(form.value.email)) {
      this.toastr.info("Digite um e-mail válido", "Informação");
      return;
    }

    //validar cpf
    if (!this.validaCPF(form.value.cpf)) {
      this.toastr.info("Digite um cpf válido", "Informação");
      return;
    }

    if (form.value.id === "") {
      this.insertRecord(form);
    } else {
      this.updateRecord(form);
    }
  }

  insertRecord(form: NgForm) {
    this.service.postUsuario(form.value).subscribe(res => {
      this.toastr.success("Dados Salvo Com Sucesso", "Informação");
      this.resetForm(form);
      this.service.refreshList();
    });
  }

  updateRecord(form: NgForm) {
    this.service.putUsuario(form.value).subscribe(res => {
      this.toastr.info("Dados Salvo Com Sucesso", "Informação");
      this.resetForm(form);
      this.service.refreshList();
    });
  }

  validarEmail(email: string) {
    var emailPattern = /^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$/;
    return emailPattern.test(email);
  }

  validaCPF(strCPF: string) {
    var Soma;
    var Resto;
    Soma = 0;

    var exp = /\.|\-/g;
    strCPF = strCPF.toString().replace(exp, "");

    if (strCPF == "00000000000") return false;

    for (let i = 1; i <= 9; i++)
      Soma = Soma + parseInt(strCPF.substring(i - 1, i)) * (11 - i);
    Resto = (Soma * 10) % 11;

    if (Resto == 10 || Resto == 11) Resto = 0;
    if (Resto != parseInt(strCPF.substring(9, 10))) return false;

    Soma = 0;
    for (let i = 1; i <= 10; i++)
      Soma = Soma + parseInt(strCPF.substring(i - 1, i)) * (12 - i);
    Resto = (Soma * 10) % 11;

    if (Resto == 10 || Resto == 11) Resto = 0;
    if (Resto != parseInt(strCPF.substring(10, 11))) return false;
    return true;
  }
}
