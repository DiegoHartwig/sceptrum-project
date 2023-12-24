import { ref } from 'vue';
import { defineStore } from 'pinia';
import http from '@/services/http.js';

export const useAuth = defineStore('auth', () => {
    const token = ref(localStorage.getItem('token'));

    function setToken(tokenValor){
        localStorage.setItem('token', tokenValor);
        token.value = tokenValor;
    }

    function estaAutenticado(){
        return token.value;
    }

    async function verificarTokenValido(){
        try {
            const bearerToken = 'Bearer ' + token.value;
            const {data} = await http.get('/api/Token/VerificarTokenValido', {
                headers: {
                    Authorization: bearerToken
                }
            });  
            return data;
        } catch (error) {
            console.log(error.response.data);
        }
    }

    function clear(){
        localStorage.removeItem('token');
        token.value = '';
    }

    return {
        token,
        setToken,  
        verificarTokenValido,
        estaAutenticado,
        clear       
    }

})
