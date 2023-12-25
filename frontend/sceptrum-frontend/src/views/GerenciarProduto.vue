<template>
    <q-layout>
        <q-page-container>
            <q-page padding>
                <h4>Gerenciar Produto</h4>
                <q-page padding>
                    <q-form
                        @submit="onSubmit"     
                        @reset="onReset"         
                        class="row q-col-gutter-sm"
                        >                 
                        
                        <q-input
                            outlined
                            v-model="formulario.nome"
                            label="Nome"                    
                            lazy-rules
                            class="col-lg-12 col-xs-12"
                            :rules="[ val => val && val.length > 0 || 'Preencha o campo nome.']"
                        />   

                        <div class="col-lg-12 col-xs-12">
                            <label>Descrição</label>
                            <q-editor 
                                v-model="formulario.descricao" 
                                min-height="5rem"
                                lasy-rules                                
                            />
                        </div>
                            
                        <q-input
                            outlined
                            v-model="formulario.preco"
                            label="Preço"                    
                            lazy-rules
                            class="col-lg-6 col-xs-12"
                            :rules="[ val => val && val.length > 0 || 'Preencha o campo preço.']"
                        />

                        <q-input
                            outlined
                            v-model="formulario.estoque"
                            label="Estoque"                    
                            lazy-rules
                            class="col-lg-6 col-xs-12"
                            :rules="[ val => val && val.length > 0 || 'Preencha o campo estoque.']"
                        />

                        <q-input
                            outlined
                            v-model="formulario.imagem"
                            label="Imagem"                    
                            lazy-rules
                            class="col-lg-12 col-xs-12"
                            :rules="[ val => val && val.length > 0 || 'Preencha o campo imagem.']"
                        />

                        <q-input
                            outlined
                            v-model="formulario.categoriaId"
                            label="Categoria"                    
                            lazy-rules
                            class="col-lg-12 col-xs-12"
                            :rules="[ val => val && val.length > 0 || 'Preencha o campo categoria.']"
                        />

                        <div class="col-12 q-gutter-sm">
                            <q-btn 
                                label="Salvar" 
                                color="primary" 
                                class="float-right" 
                                icon="save"
                                type="submit"
                                >
                            </q-btn>
                            <q-btn 
                                label="Cancelar" 
                                color="secondary" 
                                class="float-right"
                                :to="{ name :'produtos'}">
                            </q-btn>
                        </div>

                    </q-form>
                </q-page>    
            </q-page>
        </q-page-container>
    </q-layout>
</template>

<script>
import { defineComponent, ref, onMounted } from 'vue'
import produtosService from '@/services/produtosService.js'
import { useQuasar } from 'quasar'
import { useRouter, useRoute } from 'vue-router'

export default defineComponent({
    name: 'GerenciarProduto',
    setup(){
        const $q = useQuasar()
        const router = useRouter()
        const route = useRoute()
        const { metodoPost, metodoGetById, metodoUpdate } = produtosService()
        const formulario = ref({
            descricao: '',
            nome: '',
            preco: '',
            estoque: '',
            imagem: '',
            categoria: ''
        })

        onMounted(async () => {
            if(route.params.id){
                buscarDadosProdutoPorId(route.params.id)
            }
        })

        const buscarDadosProdutoPorId = async (id) => {
            try { 
                const response = await metodoGetById(id) 
                formulario.value = response  
            } catch (error) { 
                console.error(error)
            }
        }

        const onSubmit = async () => {
            try {
                if(formulario.value.id){
                    await metodoUpdate(formulario.value)
                    $q.notify({ message: 'Produto atualizado com sucesso.', icon: 'check', color: 'positive'})
                } else {
                    await metodoPost(formulario.value)
                    $q.notify({ message: 'Novo produto cadastrado com sucesso.', icon: 'check', color: 'positive'})
                    router.push({ name: 'produtos'})
                }         
            } catch (error) {
                $q.notify({ message: 'Ocorreu um erro ao salvar.', icon: 'times', color: 'negative'})
            }
        }

        return {
            formulario,
            onSubmit
        }
    }
})
</script>

<style scoped>

</style>
