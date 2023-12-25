import '@quasar/extras/material-icons/material-icons.css';
import 'quasar/src/css/index.sass';
import { QToolbar, QToolbarTitle, QBtn, QForm, QCard, QPageContainer, Dialog, Notify } from 'quasar';

export default {
  config: {},
  plugins: {
    Dialog,
    Notify
  },
  components: {
    QToolbar, 
    QToolbarTitle,
    QBtn,
    QForm,   
    QCard,
    QPageContainer   
  },
}
