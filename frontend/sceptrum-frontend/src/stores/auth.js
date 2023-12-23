import { ref } from 'vue';
import { defineStore } from 'pinia';
import http from '@/services/http.js';

export const useAuth = defineStore('auth', () => {
    const token = ref(localStorage.getItem('token'));
    const usuario = ref(JSON.parse(localStorage.getItem('usuario')));

    function setToken(tokenValor){
        localStorage.setItem('token', tokenValor);
        token.value = tokenValor;
    }

    function setUsuario(usuarioValor){
        localStorage.setItem('usuario', usuarioValor);
        token.value = usuarioValor;
    }

    async function verificarTokenValido(){
        try {
            console.log("chamou funcao verificar token valido");
            const bearerToken = 'Bearer ' + token.value;
            const {data} = await http.get('/api/Token/VerificarTokenValido', {
                headers: {
                    Authorization: bearerToken
                }
            });
            console.log("VerificarTokenValido");
            return data;
        } catch (error) {
            console.log(error.response.data);
        }
    }

    return {
        token,
        setToken,
        setUsuario,
        verificarTokenValido
    }

})
