using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQL_Teacher_API.Sistema.Analisis.Interpretes.CQL
{
    public class Gramatica_CQL : Grammar
    {

        public Gramatica_CQL() : base(caseSensitive: false)
        {
            #region COMENTARIOS
                //COMENTARIOS
                CommentTerminal comentarioLinea = new CommentTerminal("comentarioLinea", "//", "\n", "\r\n", "\r", "\u2085", "\u2028", "\u2029");
                CommentTerminal comentarioMultiLinea = new CommentTerminal("comentarioMultiLinea", "/*", "*/");
            #endregion

            #region TERMINALES
                //ACEPTACION
                var aceptacion = ToTerm("$");

                //IDENTIFICADOR
                IdentifierTerminal identificador = new IdentifierTerminal("identificador");

                //TIPOS DE DATOS Y VALOR NULO
                var _null = ToTerm("null");

                var _int = ToTerm("int");
                RegexBasedTerminal numeroEntero = new RegexBasedTerminal("int", "[0-9]+");

                var _double = ToTerm("double");
                RegexBasedTerminal numeroDecimal = new RegexBasedTerminal("double", "[0-9]+\\.[0-9]+");

                var _string = ToTerm("string");
                StringLiteral cadena = new StringLiteral("string", "\"");

                var _boolean = ToTerm("boolean");
                RegexBasedTerminal valorBooleano = new RegexBasedTerminal("boolean", "true|false");

                var _date = ToTerm("date");
                RegexBasedTerminal fecha = new RegexBasedTerminal("date", "[0-2][0-9]{3}-(0[0-9]|1[0-2])-(0[0-9]|1[0-9]|2[0-9]|3[0-1])");

                var _time = ToTerm("time");
                RegexBasedTerminal hora = new RegexBasedTerminal("time", "(0[0-9]|1[0-9]|2[0-4])-([0-5][0-9]|60)-([0-5][0-9]|60)");

                var _counter = ToTerm("counter");

                //PALABRAS RESERVADAS
                var _create = ToTerm("create");
                var _alter = ToTerm("alter");
                var _delete = ToTerm("delete");
                var _type = ToTerm("type");
                var _exists = ToTerm("exists");
                var _add = ToTerm("add");
                var _database = ToTerm("database");
                var _use = ToTerm("use");
                var _drop = ToTerm("drop");
                var _table = ToTerm("table");
                var _primary = ToTerm("primary");
                var _key = ToTerm("key");
                var _truncate = ToTerm("truncate");
                var _commit = ToTerm("commit");
                var _rollback = ToTerm("rollback");
                var _user = ToTerm("user");
                var _with = ToTerm("with");
                var _password = ToTerm("password");
                var _grant = ToTerm("grant");
                var _on = ToTerm("on");
                var _revoke = ToTerm("revoke");

                //*
                var _if = ToTerm("if");
                var _not = ToTerm("not");

                //SIGNOS DE PUNTUACION
                var parentesisAbre = ToTerm("(");
                var parentesisCierra = ToTerm(")");
                var puntoYComa = ToTerm(";");
                var coma = ToTerm(",");
            #endregion

            #region TERMINALES
            NonTerminal INICIO = new NonTerminal("INICIO"),
                            INSTRUCCION = new NonTerminal("INSTRUCCION"),
                            INSTRUCCIONES = new NonTerminal("INSTRUCCIONES"),
                            TIPO_DATO = new NonTerminal("TIPO_DATO"),
                            USER_TYPE = new NonTerminal("USER_TYPE"),
                            CREAR_USER_TYPE = new NonTerminal("CREAR_USER_TYPE"),
                            SENTENCIA_NOT_EXISTS = new NonTerminal("SENTENCIA_NOT_EXISTS"),
                            SENTENCIA_EXISTS = new NonTerminal("SENTENCIA_EXISTS"),
                            LISTA_ELEMENTOS_USER_TYPE = new NonTerminal("LISTA_ELEMENTOS_USER_TYPE"),
                            CONTENIDO_USER_TYPE = new NonTerminal("CONTENIDO_USER_TYPE"),
                            ELEMENTO_USER_TYPE = new NonTerminal("ELEMENTO_USER_TYPE"),
                            ALTERAR_ADD_USER_TYPE = new NonTerminal("ALTERAR_ADD_USER_TYPE"),
                            ALTERAR_DELETE_USER_TYPE = new NonTerminal("ALTERAR_DELETE_USER_TYPE"),
                            LISTA_NOMBRE_ELEMENTOS = new NonTerminal("LISTA_NOMBRE_ELEMENTOS"),
                            ELIMINAR_USER_TYPE = new NonTerminal("ELIMINAR_USER_TIPE"),
                            SENTENCIAS_DDL = new NonTerminal("SENTENCIAS_DDL"),
                            CREATE_BD = new NonTerminal("CREATE_BD"),
                            USE_BD = new NonTerminal("USE_BD"),
                            DROP_BD = new NonTerminal("DROP_BD"),
                            CREATE_TABLE = new NonTerminal("CREATE_TABLE"),
                            CONTENIDO_TABLA = new NonTerminal("CONTENIDO_TABLA"),
                            LISTA_COLUMNAS_TABLA = new NonTerminal("LISTA_COLUMNAS_TABLA"),
                            COLUMNA_TABLA = new NonTerminal("COLUMNA_TABLA"),
                            TIPO_DATO_COLUMNA_TABLA = new NonTerminal("TIPO_DATO_COLUMNA_TABLA"),
                            COLUMNA_PRIMARY_KEY = new NonTerminal("COLUMNA_PRIMARY_KEY"),
                            DEFINICION_LLAVE_PRIMARIA_COMPUESTA = new NonTerminal("DEFINICION_LLAVE_PRIMARIA_COMPUESTA"),
                            ALTER_TABLE_ADD = new NonTerminal("ALTER_TABLE_ADD"),
                            ALTER_TABLE_DELETE = new NonTerminal("ALTER_TABLE_DELETE"),
                            LISTA_COLUMNAS_TABLA_ALTER_ADD = new NonTerminal("LISTA_COLUMNAS_TABLA_ALTER_ADD"),
                            COLUMNA_TABLA_ALTER_ADD = new NonTerminal("COLUMNA_TABLA_ALTER_ADD"),
                            DROP_TABLE = new NonTerminal("DROP_TABLE"),
                            TRUNCATE_TABLE = new NonTerminal("TRUNCATE_TABLE"),
                            SENTENCIAS_TCL = new NonTerminal("SENTENCIAS_TCL"),
                            COMMIT = new NonTerminal("COMMIT"),
                            ROLLBACK = new NonTerminal("ROLLBACK"),
                            SENTENCIAS_DCL = new NonTerminal("SENTENCIAS_DCL"),
                            CREATE_USER = new NonTerminal("CREATE_USER"),
                            GRANT = new NonTerminal("GRANT"),
                            REVOKE = new NonTerminal("REVOKE")
                ;
            #endregion

            #region PREFERENCIAS
            this.Root = INICIO;
                this.NonGrammarTerminals.Add(comentarioLinea);
                this.NonGrammarTerminals.Add(comentarioMultiLinea);
                this.MarkPunctuation("$", "(", ")", ";");
                this.MarkPunctuation("create", "type", "if", "not", "alter", "add", "delete", "database", "use", "drop", "table", "key", "primary", "truncate", "commit", "rollback", "user", "with", "password", "grant", "on", "revoke");
                this.MarkTransient(INICIO, INSTRUCCION, TIPO_DATO, SENTENCIA_NOT_EXISTS, SENTENCIA_EXISTS, USER_TYPE, CONTENIDO_USER_TYPE, SENTENCIAS_DDL, CONTENIDO_TABLA, TIPO_DATO_COLUMNA_TABLA, DEFINICION_LLAVE_PRIMARIA_COMPUESTA, SENTENCIAS_TCL, SENTENCIAS_DCL);
            #endregion

            #region GRAMATICA

                INICIO.Rule = INSTRUCCIONES + aceptacion
                        | aceptacion
                ;

                INSTRUCCIONES.Rule = MakePlusRule(INSTRUCCIONES, INSTRUCCION);

                INSTRUCCION.Rule = USER_TYPE  //CONTIENE ESTRUCTURAS CREATE, ALTER ADD, ALTER DELETE Y DELETE
                        | SENTENCIAS_DDL //CONTIENE LAS SENTENCIAS DEL LENGUAJE DDL (CREATE DB, USE DB, DROP DB, CREATE TABLE, ETC.)
                        | SENTENCIAS_TCL //CONTIENE LAS SENTENCIAS DEL LENGUAJE TCL (COMMIT Y ROLLBACK)
                        | SENTENCIAS_DCL //CONTIENE LAS SENTENCIAS DEL LENGUAJE DCL (CREATE USER, GRANT, REVOKE)
                ;

                #region Generalidades

                    USER_TYPE.Rule = CREAR_USER_TYPE | ALTERAR_ADD_USER_TYPE | ALTERAR_DELETE_USER_TYPE | ELIMINAR_USER_TYPE;

                    CREAR_USER_TYPE.Rule = _create + _type + SENTENCIA_NOT_EXISTS + identificador + CONTENIDO_USER_TYPE; //ESTRUCTURA CREATE USER TYPE

                    SENTENCIA_NOT_EXISTS.Rule = _if + _not + _exists //SENTENCIA PARA ACEPTAR EL 'if not exist'
                            | Empty
                    ;

                    SENTENCIA_EXISTS.Rule = _if + _exists //SENTENCIA PARA ACEPTAR EL 'if exist'
                            | Empty
                    ;

                    CONTENIDO_USER_TYPE.Rule = parentesisAbre + LISTA_ELEMENTOS_USER_TYPE + parentesisCierra + puntoYComa; //PARA EL CONTENIDO DE UN USER TYPE REUTILIZABLE PARA CREATE Y ADD

                    LISTA_ELEMENTOS_USER_TYPE.Rule = MakePlusRule(LISTA_ELEMENTOS_USER_TYPE, coma, ELEMENTO_USER_TYPE); //LISTA DE ELELMENTOS O ATRIBUTOS DE UN USER TYPE

                    ELEMENTO_USER_TYPE.Rule = identificador + TIPO_DATO; //ESTRUCTURA QUE CONFORMA LOS ELEMENTOS EN UN USER TYPE

                    ALTERAR_ADD_USER_TYPE.Rule = _alter + _type + identificador + _add + CONTENIDO_USER_TYPE; //ESTRUCTURA PARA ALTER USER TYPE ADD REUTILIZANDO PARTE DE LA ESTRUCTURA CREATE

                    ALTERAR_DELETE_USER_TYPE.Rule = _alter + _type + identificador + _delete + parentesisAbre + LISTA_NOMBRE_ELEMENTOS + parentesisCierra + puntoYComa; //ESTRUCTURA PARA ALTER USER TYPE DELETE

                    LISTA_NOMBRE_ELEMENTOS.Rule = MakePlusRule(LISTA_NOMBRE_ELEMENTOS, coma, identificador); //LISTA DE NOMBRES PARA USO VARIADO EN LA GRAMATICA

                    ELIMINAR_USER_TYPE.Rule = _delete + _type + identificador + puntoYComa;  //ESTRUCTURA PARA DELETE DE UN USER TYPE

                    /**/
                    TIPO_DATO.Rule = _int | _double | _string | _boolean | _date | _time; //debe soportar collections, types

                #endregion

                #region DDL

                    SENTENCIAS_DDL.Rule = CREATE_BD | USE_BD | DROP_BD | CREATE_TABLE | ALTER_TABLE_ADD | ALTER_TABLE_DELETE | DROP_TABLE | TRUNCATE_TABLE;

                    CREATE_BD.Rule = _create + _database + SENTENCIA_NOT_EXISTS + identificador + puntoYComa; //ESTRUCTURA PARA CREAR UNA BASE DE DATOS

                    USE_BD.Rule = _use + identificador + puntoYComa; //ESTRUCTURA PARA USAR UNA BASE DE DATOS

                    DROP_BD.Rule = _drop + _database + identificador + puntoYComa; //ESTRUCTURA PARA DROPEAR UNA BASE DE DATOS

                    CREATE_TABLE.Rule = _create + _table + SENTENCIA_NOT_EXISTS + identificador + parentesisAbre + LISTA_COLUMNAS_TABLA + parentesisCierra + puntoYComa; //ESTRUCTURA QUE REPRESENTA UNA TABLA CQL

                    LISTA_COLUMNAS_TABLA.Rule = MakePlusRule(LISTA_COLUMNAS_TABLA, coma, CONTENIDO_TABLA); //listado de columnas en la definicion de una tabla

                    CONTENIDO_TABLA.Rule = COLUMNA_TABLA | COLUMNA_PRIMARY_KEY | DEFINICION_LLAVE_PRIMARIA_COMPUESTA;

                    COLUMNA_TABLA.Rule = identificador + TIPO_DATO_COLUMNA_TABLA; //contiene la estructura de una columna en una tabla

                    COLUMNA_PRIMARY_KEY.Rule = identificador + TIPO_DATO_COLUMNA_TABLA + _primary + _key; //definicion para una llave primaria simple

                    TIPO_DATO_COLUMNA_TABLA.Rule = TIPO_DATO | _counter; //acepta los tipos de dato de CQL ademas del tipo counter solo para columnas

                    DEFINICION_LLAVE_PRIMARIA_COMPUESTA.Rule = _primary + _key + parentesisAbre + LISTA_NOMBRE_ELEMENTOS + parentesisCierra; //estructura que contiene la definicion de una lleva primaria compuesta

                    ALTER_TABLE_ADD.Rule = _alter + _table + identificador + _add + LISTA_COLUMNAS_TABLA_ALTER_ADD + puntoYComa; //contiene la estructura para un alter table add

                    LISTA_COLUMNAS_TABLA_ALTER_ADD.Rule = MakePlusRule(LISTA_COLUMNAS_TABLA_ALTER_ADD, coma, COLUMNA_TABLA_ALTER_ADD); //listado de columnas en la definicion de una tabla

                    COLUMNA_TABLA_ALTER_ADD.Rule = identificador + TIPO_DATO; //contiene la estructura de una columna en una tabla para alter add

                    ALTER_TABLE_DELETE.Rule = _alter + _table + identificador + _drop + LISTA_NOMBRE_ELEMENTOS + puntoYComa; //contiene la estructura para un alter table drop

                    DROP_TABLE.Rule = _drop + _table + SENTENCIA_EXISTS + identificador + puntoYComa; //contiene la estructura para un drop table

                    TRUNCATE_TABLE.Rule = _truncate + _table + identificador + puntoYComa; //contiene la estructura para un truncate table

                #endregion

                #region TCL

                    SENTENCIAS_TCL.Rule = COMMIT | ROLLBACK;

                    COMMIT.Rule = _commit + puntoYComa; //contiene la estructura del comando commit

                    ROLLBACK.Rule = _rollback + puntoYComa; //contiene la estructura del comando rollback

                #endregion

                //TODO -> nombre y contraseña en create user puede ser numerica tambien, revisar uso de identificadores para cambiar por algun tipo que sea mas flexible

                #region DCL

                    SENTENCIAS_DCL.Rule = CREATE_USER | GRANT | REVOKE;

                    CREATE_USER.Rule = _create + _user + identificador + _with + _password + identificador + puntoYComa;

                    GRANT.Rule = _grant + identificador + _on + identificador + puntoYComa;

                    REVOKE.Rule = _revoke + identificador + _on + identificador + puntoYComa;

                #endregion

                #region DML
                #endregion

                #region FCL
                #endregion

            #endregion
        }
        public override void ReportParseError(ParsingContext context)
        {
            base.ReportParseError(context);
            if (context.CurrentToken.ValueString.Contains("Invalid character"))
                Console.WriteLine("ERROR LEXICO NO SE RECONOCIO ESTE SIMBOLO " + context.CurrentToken.ValueString.ToString() + " EN LINEA " + (context.Source.Location.Line + 1) + " Y COLUMNA " + context.Source.Location.Column);
            else
                Console.WriteLine("ERROR SINTACTICO NO SE ESPERABA ESTE SIMBOLO " + context.CurrentToken.ValueString.ToString() + " EN LINEA " + (context.Source.Location.Line + 1) + " Y COLUMNA " + context.Source.Location.Column);
        }
    }

}