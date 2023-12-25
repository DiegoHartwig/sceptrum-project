<template>
<q-layout>
    <q-page-container>
        <q-page padding>
            <q-table
                title="Produtos"
                :rows="produtos"
                :columns="columns"
                row-key="name"
            >
            <template v-slot:top>
                <span class="text-h5">Produtos</span> 
                <q-space/>
                <q-btn color="primary" label="Novo" :to="{ name: 'gerenciarProduto'}"/>     
            </template>

            <template v-slot:body-cell-actions="props">
                <q-td :props="props" class="q-gutter-sm">
                    <q-btn icon="edit" color="info" dense @click="editarProduto(props.row.id)"/>
                    <q-btn icon="delete" color="negative" dense @click="deletarProduto(props.row.id)"/>
                </q-td>
            </template>
            </q-table>

        </q-page>
    </q-page-container>
</q-layout>
</template>

<script>
import { defineComponent, ref, onMounted } from 'vue'
import produtosService from '@/services/produtosService.js'
import { useQuasar } from 'quasar'
import { useRouter } from 'vue-router'

export default defineComponent({
    name: 'Produtos',
    setup(){
        const produtos = ref([])

        const { metodoGet, metodoDelete } = produtosService()

        const columns = [
            { name: 'id', field: 'id', label: 'Id', sortable: true, align: 'left' },
            { name: 'descricao', field: 'descricao', label: 'Descrição', sortable: true, align: 'left' },
            { name: 'nome', field: 'nome', label: 'Nome', sortable: true, align: 'left' },
            { name: 'preco', field: 'preco', label: 'Preço', sortable: true, align: 'left' },
            { name: 'estoque', field: 'estoque', label: 'Estoque', sortable: true, align: 'left' },
            { name: 'imagem', field: 'imagem', label: 'Imagem', sortable: true, align: 'left' },
            { name: 'categoriaId', field: 'categoriaId', label: 'Categoria', sortable: true, align: 'left' },
            { name: 'actions', field: 'actions', label: 'Ações', align: 'right' },
        ]

        const $q = useQuasar()

        const router = useRouter()

        onMounted(() => {
            listarProdutos()
        })

        const listarProdutos = async () => {
            try {
                const data = await metodoGet()             
                produtos.value = data;                                   
            } catch (error) {
                console.error(error)
            }
        }      
        
        const deletarProduto = async (id) => {
            try {
                $q.dialog({
                    title:'Deletar',
                    message: 'Você tem certeza que deseja deletar?',
                    cancel: true,
                    persistent: true
                }).onOk(async () => {
                    await metodoDelete(id)
                    $q.notify({ message: 'Deletado com sucesso.', icon: 'check', color: 'positive'})
                    await listarProdutos()
                })
            } catch (error) {
                $q.notify({ message: 'Erro ao deletar.', icon: 'times', color: 'negative'})
            } 
        }

        const editarProduto = (id) => {
            router.push({ name: 'gerenciarProduto', params: { id }})
        }

        return {
            produtos,
            columns,
            deletarProduto,
            editarProduto
        }
    }
})

</script>

<style lang="scss" scoped>

</style>