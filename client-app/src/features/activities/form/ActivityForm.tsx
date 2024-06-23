import { observer } from 'mobx-react-lite';
import { useEffect, useState } from 'react';
import { Link, useNavigate, useParams } from 'react-router-dom';
import { Button, Header, Segment } from "semantic-ui-react";
import LoadingComponent from '../../../app/layout/LoadingComponent';
import { useStore } from '../../../app/stores/store';
import { Formik,Form } from 'formik';
import * as Yup from 'yup';
import MyTextInput from '../../../app/common/forms/MyTextinput';
import MyTextTextAra from '../../../app/common/forms/MyTextArea';
import MySelectInput from '../../../app/common/forms/MySelectInput';
import { categoryOptions } from '../../../app/common/potions/categoryOptions';
import MyDateInput from '../../../app/common/forms/MyDateInput';
import { ActivityFormValues } from '../../../app/models/activity';
import { v4 as uuid } from 'uuid';

export default observer(function ActivityForm() {
    const {activityStore} = useStore();
    const {createActivity, updateActivity, 
        loading, loadActivity, loadingInitial} = activityStore;
    const {id} = useParams();
    const navigate = useNavigate();

    const [activity, setActivity] = useState<ActivityFormValues>(new ActivityFormValues());
    const validationshema = Yup.object({
        title: Yup.string().required('The activity title is required'),
        description: Yup.string().required('The activity description is required'),
        category: Yup.string().required(),
        date: Yup.string().required('Date is required'),
        city: Yup.string().required(),
        venue: Yup.string().required()
    })
    useEffect(() => {
        if (id) loadActivity(id).then(activity => setActivity(new ActivityFormValues(activity)));
    }, [id, loadActivity]);

    function handleFormSubmit(activity: ActivityFormValues) {
        if (!activity.id) {
            let newActivity = {
                ...activity,
                id: uuid()
            }           
            createActivity(newActivity).then(() => navigate(`/activities/${newActivity.id}`))
        } else {
            updateActivity(activity).then(() => navigate(`/activities/${activity.id}`))
        }
    }

   

    if (loadingInitial) return <LoadingComponent content='Loading activity...' />

    return (
        <Segment clearing>
        <Header content='Activity Details' sub color='teal' />
        <Formik 
        validationSchema={validationshema}
        enableReinitialize 
        initialValues={activity} 
        onSubmit={values => handleFormSubmit(values)}>
            {({handleSubmit,isValid,isSubmitting,dirty}) => (
                 <Form className='ui form' onSubmit={handleSubmit} autoComplete='off'>         
                 <MyTextInput placeholder='Title'  name='title'/>
                 <MyTextTextAra placeholder='Description' name='description' rows={3}  />
                 <MySelectInput options={categoryOptions} placeholder='Category' name='category'  />
                 <MyDateInput 
                    placeholderText='Date'  
                    name='date'
                    showTimeSelect
                    timeCaption='time'
                    dateFormat='MMMM d, yyyy h:mm aa'
                 />
                 <Header content='Location Details' sub color='teal' />
                 <MyTextInput placeholder='City'  name='city'  />
                 <MyTextInput placeholder='Venue'  name='venue'  />
                 <Button 
                 disabled={isSubmitting || !dirty || !isValid}
                 loading={isSubmitting} 
                 floated='right' positive type='submit' content='Submit' />
                 <Button as={Link} to='/activities' floated='right' type='button' content='Cancel' />
             </Form>
            )}
        </Formik>           
        </Segment>
    )
})